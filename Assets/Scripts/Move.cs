using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float SCALE_MOVEMENT = 20.0f;
    public float gravity = 20.0f;
    private Transform playerTransform;
    private Animator playerAnim;

    private Rigidbody rb;
    private Vector3 direction;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
        playerAnim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerTransform.Translate(direction * SCALE_MOVEMENT * Time.deltaTime);

    }

}
