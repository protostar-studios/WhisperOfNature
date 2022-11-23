using UnityEngine;

// ================================================== //
//            Player Control Center Script            //
// ================================================== //

/*
Credits:

Add force part of jump behaviour inspired from this link:
https://answers.unity.com/questions/1020197/can-someone-help-me-make-a-simple-jump-script.html

~Varun

*/

[RequireComponent(typeof(Rigidbody))]

public class PlayerMainController : MonoBehaviour
{

    // DEBUG option
    private bool DEBUG = false;
    // Move and Camera Basics
    public float SCALE_MOVEMENT = 18.0f;
    public float rotateSpeed = 360;
    public float SlideForce = 10f;
    public Camera mainCamera;
    
    public Vector3 jump;
    public float SCALE_JUMP = 3.5f;
    public float jumpForce;
    public bool isGrounded;
    public float MUD_SPEED = 10.0f;

    private Animator playerAnim;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private Quaternion faceDirection;
    private SeasonManager seasonManager;
    public float walkingSpeed;                 // The variable storing current walking speed
    private float normalSpeed;                  // Set to SCALE_MOVEMENT at start
    private bool jumping;
    private float input_h = 0.0f;
    private float input_v = 0.0f;
    private string joyStick = "PS_";
    public float animWalkingSpeed = 0.0f;

    // https://answers.unity.com/questions/665352/shot-delay-between-button-press-c.html
    public float timeBetweenJumps = 1f;
    private float timestamp;

    // Seasonal Changes
    private float curMoveVel;
    private float curJumpVel;
    private bool isFrozen;
    private bool onIce = false;
    public bool onMud = false;
    
    public RespawnManager respawnManager;
    private int curSeason = -1;

    // Winter Player Freeze Control
    public float freezeTime = 7.0f;
    public float recoverTime = 1.0f;
    public float opacity = 0f;
    public GameObject iceCube;

    private Renderer iceShader;
    private float curOpa;
    private Vector4 albedo;
    // Player audio general
    
    public AudioClip jumpingWhoosh;
    public AudioClip landingAudio;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        jumpForce = SCALE_JUMP;
        walkingSpeed = SCALE_MOVEMENT;
        normalSpeed = SCALE_MOVEMENT;
        seasonManager = FindObjectOfType<SeasonManager>();
        mainCamera = FindObjectOfType<Camera>();
        respawnManager = FindObjectOfType<RespawnManager>();
        joyStick = FindObjectOfType<JoyStickManager>().joyStick;

        // Set cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Get components
        rb = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
        setComponents();
        jump = new Vector3(0.0f, 3.8f, 0.0f);
        setGrounded();
        iceShader = null;
        curOpa = opacity;
    }

    void setComponents(){
        playerAnim = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        // Movement
        input_h = Input.GetAxis("Horizontal");
        input_v = Input.GetAxis("Vertical");

        // Debug Restart
        if (DEBUG == true && Input.GetKeyDown(KeyCode.R)){
            try{ 
                PauseMenu.died = true;
                FindObjectOfType<PauseMenu>().SetPause();
                // Respawn();
            }catch (System.Exception){
                Debug.Log("Please add Respawn Menu Object to the scene");
            }
        }

        // Jumping
        if(Input.GetButtonDown("Jump") || Input.GetButtonDown(joyStick + "Jump")){
            jumping = true;
        } else if(Input.GetButtonUp("Jump") || Input.GetButtonUp(joyStick + "Jump")){
            jumping = false;
        }
        if(seasonManager.curSeason == 0 && onMud){
            SCALE_MOVEMENT = MUD_SPEED;
            if(!jumping){
                FindObjectOfType<SinkInMud>().setPlayerOnMud();
            }else{
                FindObjectOfType<SinkInMud>().resetPlayerOnMud();
            }
            if(walkingSpeed > MUD_SPEED){
                walkingSpeed = MUD_SPEED;
            }
        }else{
            SCALE_MOVEMENT = normalSpeed;
            FindObjectOfType<SinkInMud>().resetPlayerOnMud();
        }
    }

    float walkingSpeedVal;

    // Update is called once per frame
    void FixedUpdate()
    {
        playerAnim = transform.GetComponentInChildren<Animator>();
        // update Season
        if(curSeason != seasonManager.curSeason){
            GetComponent<ModelManager>().ChangeSeasonModel();
            curSeason = seasonManager.curSeason;
        }
        bool hasHorizontalInput = !Mathf.Approximately(input_h, 0f);
        bool hasVerticalInput = !Mathf.Approximately(input_v, 0f);
        // bool isWalking = hasHorizontalInput || hasVerticalInput;
        // playerAnim.SetBool("isWalking", isWalking);
        if(hasHorizontalInput || hasVerticalInput){
            animWalkingSpeed = Mathf.SmoothDamp(animWalkingSpeed, 1.0f, ref walkingSpeedVal, 0.1f);
        }else{
            animWalkingSpeed = Mathf.SmoothDamp(animWalkingSpeed, 0.0f, ref walkingSpeedVal, 0.1f);
        }
        playerAnim.SetFloat("walkingSpeed", Mathf.Min(Mathf.Clamp(walkingSpeed, 0, 1), animWalkingSpeed));
        playerAnim.SetFloat("inputX", Mathf.Clamp(walkingSpeed, 0, 1) * input_h);
        playerAnim.SetFloat("inputY", Mathf.Clamp(walkingSpeed, 0, 1) * input_v);

        if(seasonManager.curSeason == 3 && !onIce){
            // Winter
            walkingSpeed = Mathf.SmoothDamp(walkingSpeed, 0, ref curMoveVel, freezeTime, 1.0f);
            jumpForce = Mathf.SmoothDamp(jumpForce, 0, ref curJumpVel, freezeTime, 0.8f*SCALE_JUMP/SCALE_MOVEMENT);
            // Debug.Log("Slow comparison: Jump: " + jumpForce + " | " + SCALE_JUMP + " Move: " + walkingSpeed + " | " + SCALE_MOVEMENT);
            if(walkingSpeed <= 0.01){
                isFrozen = true;
            }
            // Add ice on player
            if(walkingSpeed < SCALE_MOVEMENT / 2){
                opacity = Mathf.SmoothDamp(opacity, 0.7f, ref curOpa, freezeTime / 2, 0.083f);          
                if(iceShader == null){
                    GameObject newIceCube = Instantiate<GameObject>(iceCube, transform.position, transform.rotation, transform);
                    iceShader = newIceCube.transform.GetChild(0).GetComponent<Renderer>();
                }
                albedo = iceShader.materials[0].GetVector("_Color");
                iceShader.materials[0].SetVector("_Color", new Vector4(albedo.x, albedo.y, albedo.z, opacity));
            }

        }else{
            // Not Winter
            if(walkingSpeed != SCALE_MOVEMENT){
                isFrozen = false;
                walkingSpeed = Mathf.SmoothDamp(walkingSpeed, SCALE_MOVEMENT, ref curMoveVel, recoverTime, 1f);
                jumpForce = Mathf.SmoothDamp(jumpForce, SCALE_JUMP, ref curJumpVel, recoverTime, 1f*SCALE_JUMP/SCALE_MOVEMENT);
            }
            if(opacity >= 0.01f){
                opacity = Mathf.SmoothDamp(opacity, 0.0f, ref curOpa, recoverTime, 0.3f);
                albedo = iceShader.materials[0].GetVector("_Color");
                if(iceShader != null){
                    iceShader.materials[0].SetVector("_Color", new Vector4(albedo.x, albedo.y, albedo.z, opacity));
                }
            } else {
                if(iceShader != null){
                    Destroy(iceShader.transform.parent.gameObject);
                }
            }
        }

        // Player Movement Updates
        moveDirection = new Vector3(input_h, 0, input_v).normalized;

        if (!isFrozen){
            // All movement can only happen if the character is not currently frozen
            if((input_h != 0 || input_v != 0)){
                faceDirection = Quaternion.Euler(0, mainCamera.transform.rotation.eulerAngles.y, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, faceDirection, rotateSpeed * Time.deltaTime);
            }
            if(seasonManager.curSeason == 3 && onIce){
                // Sliding behaviour on ice in winter
                Debug.Log("Sliding");
                rb.AddForce(transform.TransformDirection(moveDirection) * SlideForce, ForceMode.Impulse);
            }else{
                // Regular movement
                transform.Translate(moveDirection * walkingSpeed * Time.fixedDeltaTime);    
            }

            if(!(onMud && curSeason == 0) && jumping && isGrounded  && Time.time >= timestamp)
            {
                // Jumping behaviour
                // Play one shot jumping sound
                audioSource.PlayOneShot(jumpingWhoosh);
                playerAnim.SetBool("jumping", true);
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                Debug.Log("Jumping!");
                isGrounded = false;
                onIce = false;
                // To control the time between jumps
                timestamp = Time.time + timeBetweenJumps;
            }
        }
        
    }

    // Jumping
    private void CheckCollisionWithGround(Collision other){
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("GrownFlower") || other.gameObject.CompareTag("Iceberg") || other.gameObject.CompareTag("Mud"))
        {
            if(other.GetContact(0).thisCollider.gameObject.CompareTag("Foot")){
                if(!isGrounded){
                    audioSource.PlayOneShot(landingAudio);
                    playerAnim.SetBool("jumping", false);
                    setGrounded();
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        // Check if player's on freezable water
        if(other.gameObject.CompareTag("WaterSurface")){
            onIce = true;
        }else{
            onIce = false;
        }
        // player getting hurt
        if(other.gameObject.CompareTag("FallThornyBush") || other.gameObject.CompareTag("harmfulobj")){
            isGrounded = true;
            try{ 
                PauseMenu.died = true;
                FindObjectOfType<PauseMenu>().SetPause();
                // Respawn();
            }catch (System.Exception){
                Debug.Log("Please add Respawn Menu Object to the scene");
            }
        }
        // Winning check
        if(other.gameObject.CompareTag("WinDetection")){
            Debug.Log("You win");
            Application.Quit();
        }
        if(other.gameObject.CompareTag("Mud")){
            onMud = true;
            // **** IMPORTANT **** //
            // We need to add all ground tags that are not Mud to the if statement below
        }else if(other.gameObject.CompareTag("Ground") ||
                 other.gameObject.CompareTag("GrownFlower") || 
                 other.gameObject.CompareTag("Iceberg")){
            onMud = false;
        }
        // Check ground for jumping
        CheckCollisionWithGround(other);

    }

    public void Respawn(){
        transform.position = respawnManager.curRespawn.position;
        transform.rotation = respawnManager.curRespawn.rotation;
        walkingSpeed = SCALE_MOVEMENT;
    }

    void setGrounded()
    {
        // play landing sound
        isGrounded = true;
        Debug.Log("Grounded!");
    }
    
    public void setAnimBool(string name){
        playerAnim.SetBool(name, true);
    }

    public void resetAnimBool(string name){
        Debug.Log(name);
        playerAnim.SetBool(name, false);
    }

}
