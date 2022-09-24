using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePB : MonoBehaviour
{

    private float _playerInput;
    private float _rotationInput;
    private Vector3 _userRotation;
    private bool _userJumped;

    private const float _inputScale = 0.5f;

    private Rigidbody _rigidbody;
    private Transform _transform;
    // private bool canJump=false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerInput = Input.GetAxis("Vertical");
        _rotationInput = Input.GetAxis("Horizontal");
        _userJumped = Input.GetButton("Jump"); // whatever button is mapped to jump in project settings (ex. spacebar)
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.collider.tag == "Ground")
    //     {
    //         canJump = true; // destroy this coin
    //     }
    // }

    private void FixedUpdate()
    {
        _userRotation = _transform.rotation.eulerAngles;
        _userRotation += new Vector3(0, _rotationInput, 0); // since we only want to rotate in the y direction


        _transform.rotation = Quaternion.Euler(_userRotation);
        _transform.position += _transform.forward * _playerInput * _inputScale; // the velocity is a Vector3

        if (_userJumped && (_transform.position.y <= 2))
        {
            _rigidbody.AddForce(Vector3.up, ForceMode.VelocityChange); // needs direction and force mode
            _userJumped = false;
            // canJump = false;
        }
    }
}
