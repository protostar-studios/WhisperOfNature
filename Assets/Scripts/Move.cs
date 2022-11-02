using UnityEngine;

// ================================================== //
//            Player Control Center Script            //
// ================================================== //

/*
Credits:

Jump behaviour largely inspired from this link:
https://answers.unity.com/questions/1020197/can-someone-help-me-make-a-simple-jump-script.html

~Varun

*/

[RequireComponent(typeof(Rigidbody))]

public class Move : MonoBehaviour
{

    // DEBUG option
    private bool DEBUG = false;

    public float SCALE_MOVEMENT = 20.0f;
    public float rotateSpeed = 360;
    public float SlideForce = 10f;
    public Camera mainCamera;
    private Animator playerAnim;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private Quaternion faceDirection;
    private SeasonManager seasonManager;

    public Vector3 jump;
    public float SCALE_JUMP = 2.4f;
    public float jumpForce;
    private float walkingSpeed;

    public bool isGrounded;
    // https://answers.unity.com/questions/665352/shot-delay-between-button-press-c.html
    public float timeBetweenJumps = 1f;
    private float timestamp;

    private float curVel;
    private bool isFrozen;
    private bool onIce = false;
    
    public RespawnManager respawnManager;
    private bool jumping;
    private int curSeason = -1;

    private float input_h = 0.0f;
    private float input_v = 0.0f;
    private string joyStick = "PS_";
   
    // Start is called before the first frame update
    void Start()
    {
        jumpForce = SCALE_JUMP;
        walkingSpeed = SCALE_MOVEMENT;
        seasonManager = FindObjectOfType<SeasonManager>();
        mainCamera = FindObjectOfType<Camera>();
        respawnManager = FindObjectOfType<RespawnManager>();
        joyStick = FindObjectOfType<JoyStickManager>().joyStick;

        // Set cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Get components
        rb = gameObject.GetComponent<Rigidbody>();
        setComponents();
        jump = new Vector3(0.0f, 3.4f, 0.0f);
        setGrounded();

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
            Respawn();
        }

        // Jumping
        if(Input.GetButtonDown("Jump") || Input.GetButtonDown(joyStick + "Jump")){
            jumping = true;
        } else if(Input.GetButtonUp("Jump") || Input.GetButtonUp(joyStick + "Jump")){
            jumping = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // update Season
        if(curSeason != seasonManager.curSeason){
            setComponents();
            curSeason = seasonManager.curSeason;
        }
        bool hasHorizontalInput = !Mathf.Approximately(input_h, 0f);
        bool hasVerticalInput = !Mathf.Approximately(input_v, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        playerAnim.SetBool("isWalking", isWalking);
        if(seasonManager.curSeason == 3){
            walkingSpeed = Mathf.SmoothDamp(walkingSpeed, 0, ref curVel, 12 * Time.fixedDeltaTime, 0.8f);
            jumpForce = Mathf.SmoothDamp(jumpForce, 0, ref curVel, 7 * Time.fixedDeltaTime, 1.0f);
            playerAnim.SetFloat("walkingSpeed", Mathf.Clamp(walkingSpeed, 0, 1));
            if(walkingSpeed <= 0.01){
                isFrozen = true;
            }
        }else if(walkingSpeed != SCALE_MOVEMENT){
            isFrozen = false;
            walkingSpeed = Mathf.SmoothDamp(walkingSpeed, SCALE_MOVEMENT, ref curVel, 1f, 1.0f);
            jumpForce = Mathf.SmoothDamp(jumpForce, SCALE_JUMP, ref curVel, 1f, 0.5f);
            playerAnim.SetFloat("walkingSpeed", Mathf.Clamp(walkingSpeed, 0, 1));
        }
        moveDirection = new Vector3(input_h, 0, input_v);
        if((!isFrozen) && (input_h != 0 || input_v != 0)){
            faceDirection = Quaternion.Euler(0, mainCamera.transform.rotation.eulerAngles.y, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, faceDirection, rotateSpeed * Time.deltaTime);
        }
        if(seasonManager.curSeason == 3 && onIce && !isFrozen){
            Debug.Log("Sliding");
            rb.AddForce(transform.TransformDirection(moveDirection) * SlideForce, ForceMode.Impulse);
        }else if(!isFrozen){
            transform.Translate(moveDirection * walkingSpeed * Time.fixedDeltaTime);    
        }

        if(jumping && isGrounded && !isFrozen && Time.time >= timestamp)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            Debug.Log("Jumping!");
            isGrounded = false;
            timestamp = Time.time + timeBetweenJumps;

        }
    }

    private void CheckCollisionWithGround(Collision other){
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("GrownFlower") || other.gameObject.CompareTag("Iceberg"))
        {
           if(other.GetContact(0).thisCollider.gameObject.CompareTag("Foot")){
            setGrounded();
           }
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("WaterSurface")){
            onIce = true;
        }else{
            onIce = false;
        }
        if(other.gameObject.CompareTag("FallThornyBush") || other.gameObject.CompareTag("harmfulobj")){
            isGrounded = true;
            Respawn();
        }

        if(other.gameObject.CompareTag("WinDetection")){
            Debug.Log("You win");
            Application.Quit();
        }
        
        CheckCollisionWithGround(other);

    }

    private void Respawn(){
        transform.position = respawnManager.curRespawn.position;
        transform.rotation = respawnManager.curRespawn.rotation;
        walkingSpeed = SCALE_MOVEMENT;
    }

    void setGrounded()
    {
        isGrounded = true;
        Debug.Log("Grounded!");
    }

}
