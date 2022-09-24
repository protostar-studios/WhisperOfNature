using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private float _userHorizontalInput;
    private const float SCALE_MOVEMENT = 0.1f;
    private Transform playerTransform;

    private float _userRotationInput;
    private Vector3 _userRotation;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        _userHorizontalInput = Input.GetAxis("Vertical");
        //Debug.Log(_userHorizontalInput);

        _userRotationInput = Input.GetAxis("Horizontal");
        _userRotation = playerTransform.rotation.eulerAngles; // euler angles is the xyz angles
        _userRotation += new Vector3(0, _userRotationInput, 0); // captures the 2D input of any sequence

        playerTransform.rotation = Quaternion.Euler(_userRotation);
        playerTransform.position += transform.forward * _userHorizontalInput * SCALE_MOVEMENT;

    }
}
