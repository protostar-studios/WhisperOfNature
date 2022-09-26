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
    public float gravity = 20.0f;
    public Camera mainCamera;
    private Transform playerTransform;
    private Animator playerAnim;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 faceDirection;
    private CharacterController controller;

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
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        faceDirection = new Vector3(0, mainCamera.transform.rotation.y, 0);

        playerTransform.Translate(moveDirection * SCALE_MOVEMENT * Time.deltaTime);    

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
