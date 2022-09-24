using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camTarget;
    public float xMove;
    public float yMove;

    public float distance;
    public float height = 1.5f; 

    public float MAX_ANGLE = 80f;
    public float MIN_ANGLE = -70f;


    void Start()
    {
        transform.rotation = camTarget.transform.rotation;
        transform.LookAt(camTarget.transform);
    }

    // Update is called once per frame
    void Update()
    {
        xMove += Input.GetAxis("Mouse X");
        yMove += -Input.GetAxis("Mouse Y");

        if(yMove > MAX_ANGLE){
            yMove = MAX_ANGLE;
        }

        if(yMove < MIN_ANGLE){
            yMove = MIN_ANGLE;
        }

        transform.rotation = Quaternion.Euler(yMove, xMove, 0);
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        transform.position = transform.rotation * negDistance;
    }

    private void LateUpdate() {
        transform.position += (camTarget.transform.position + Vector3.up * height);    
    }

}
