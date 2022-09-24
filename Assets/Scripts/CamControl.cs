using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mainCam;
    public GameObject camTarget;
    public float distance = 20;
    public float sensitivity = 10f;    void Start()
    {
        mainCam.transform.LookAt(camTarget.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
