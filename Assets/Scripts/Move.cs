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
    public float SCALE_MOVEMENT = 20.0f;
    private Transform playerTransform;

    private float _userLeftRightInput;
    private Animator playerAnim;

    private Rigidbody rb;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
        playerAnim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
        rb = gameObject.GetComponent<Rigidbody>();
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
        rb.AddForce(new Vector3(_userLeftRightInput, 0, 0) * SCALE_MOVEMENT * Time.deltaTime, ForceMode.Impulse);
        rb.AddForce(new Vector3(0, _userHorizontalInput, 0) * SCALE_MOVEMENT * Time.deltaTime, ForceMode.Impulse);

    

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    // private void LateUpdate() {
    //     return;
    // }
    }

}
