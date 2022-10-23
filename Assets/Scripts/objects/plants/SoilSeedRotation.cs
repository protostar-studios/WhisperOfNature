using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilSeedRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 2.0f;
    private Vector3 rotationV;
    void Start()
    {
        rotationV = new Vector3(0, rotationSpeed * Time.fixedDeltaTime, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(rotationV);
    }
}
