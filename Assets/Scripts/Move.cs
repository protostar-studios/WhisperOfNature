using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Credits:

Jump behaviour largely inspired from this link:
https://answers.unity.com/questions/1020197/can-someone-help-me-make-a-simple-jump-script.html

~Varun

*/

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{

    public float SCALE_MOVEMENT = 20.0f;
    public float rotateSpeed = 360;
    public float SlideForce = 10f;
    public Camera mainCamera;
    private Transform playerTransform;
    private Animator playerAnim;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private Quaternion faceDirection;
    private CharacterController controller;
    private SeasonManager seasonManager;

    public Vector3 jump;
    public float SCALE_JUMP = 2.0f;
    public float jumpForce;
    private float walkingSpeed;

    public bool isGrounded;
    private float curVel;
    private bool isFrozen;
    private bool onIce = false;
    private Vector3 jumpVector;
    
    private GameObject respawnPoint;
   
    // Start is called before the first frame update
    void Start()
    {
        jumpForce = SCALE_JUMP;
        walkingSpeed = SCALE_MOVEMENT;
        seasonManager = GameObject.FindObjectOfType<SeasonManager>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerTransform = gameObject.GetComponent<Transform>();
        playerAnim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        respawnPoint = GameObject.FindGameObjectsWithTag("Respawn")[0];
    }

    void OnCollisionStay()
    {
        isGrounded = true;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float input_h = Input.GetAxis("Horizontal");
        float input_v = Input.GetAxis("Vertical");
        bool hasHorizontalInput = !Mathf.Approximately(input_h, 0f);
        bool hasVerticalInput = !Mathf.Approximately(input_v, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        playerAnim.SetBool("isWalking", isWalking);
        if(seasonManager.curSeason == 3){
            walkingSpeed = Mathf.SmoothDamp(walkingSpeed, 0, ref curVel, 12 * Time.fixedDeltaTime, 0.8f);
            jumpForce = Mathf.SmoothDamp(jumpForce, 0, ref curVel, 7 * Time.fixedDeltaTime, 0.5f);
            playerAnim.SetFloat("walkingSpeed", Mathf.Clamp(walkingSpeed, 0, 1));
            if(walkingSpeed <= 0.01){
                isFrozen = true;
            }
        }else if(walkingSpeed != SCALE_MOVEMENT){
            isFrozen = false;
            walkingSpeed = Mathf.SmoothDamp(walkingSpeed, SCALE_MOVEMENT, ref curVel, 7 * Time.fixedDeltaTime, 0.5f);
            jumpForce = Mathf.SmoothDamp(jumpForce, SCALE_JUMP, ref curVel, 7 * Time.fixedDeltaTime, 0.5f);
            playerAnim.SetFloat("walkingSpeed", Mathf.Clamp(walkingSpeed, 0, 1));
        }
        moveDirection = new Vector3(input_h, 0, input_v);
        if((!isFrozen) && (input_h != 0 || input_v != 0)){
            faceDirection = Quaternion.Euler(0, mainCamera.transform.rotation.eulerAngles.y, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, faceDirection, rotateSpeed * Time.deltaTime);
        }
        if(seasonManager.curSeason == 3 && onIce && !isFrozen){
            Debug.Log("Sliding");
            gameObject.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(moveDirection) * SlideForce, ForceMode.Impulse);
        }else if(!isFrozen){
            playerTransform.Translate(moveDirection * walkingSpeed * Time.deltaTime);    
        }

        if(Input.GetButtonDown("Jump") && isGrounded && !isFrozen)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    // private void LateUpdate() {
    //     return;
    // }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("WaterSurface")){
            onIce = true;
        }else{
            onIce = false;
        }
        if(other.gameObject.CompareTag("FallThornyBush")){
            Respawn();
        }
    }

    private void Respawn(){
        playerTransform.position = respawnPoint.transform.position;
        playerTransform.rotation = respawnPoint.transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }
}
