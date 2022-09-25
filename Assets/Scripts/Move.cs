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

    private float _userHorizontalInput;
    public float SCALE_MOVEMENT = 0.1f;
    private Transform playerTransform;

    private float _userLeftRightInput;
    public Animator playerAnim;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
        playerAnim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {

        _userHorizontalInput = Input.GetAxis("Vertical");
        //Debug.Log(_userHorizontalInput);

        _userLeftRightInput = Input.GetAxis("Horizontal");

        if(_userHorizontalInput != 0 || _userLeftRightInput != 0){
            Debug.Log("11");
            playerAnim.SetBool("isWalking", true);
        } else {
            Debug.Log("22");
            playerAnim.SetBool("isWalking", false);
        }

        playerTransform.position += transform.right * _userLeftRightInput * SCALE_MOVEMENT;
        playerTransform.position += transform.forward * _userHorizontalInput * SCALE_MOVEMENT;

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }
}
