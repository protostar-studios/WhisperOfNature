using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private float _userHorizontalInput;
    public float SCALE_MOVEMENT = 0.1f;
    private Transform playerTransform;

    private float _userLeftRightInput;
    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
        playerAnim = gameObject.GetComponent<Animator>();
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

    }
}
