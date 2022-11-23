using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkInMud : MonoBehaviour
{
    private string joyStick = "PS_";
    private bool jumping;
    private bool playerOnMud = false;
    private Transform colliderTrans;
    public float sink_distance = 0.2f;
    public float y_offset = 0.0f;
    private float y_origin = 0.0f;
    private float damp_ref;
    // Start is called before the first frame update
    void Start()
    {
        joyStick = FindObjectOfType<JoyStickManager>().joyStick;
        colliderTrans = transform.GetChild(1);
        y_origin = colliderTrans.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetButtonDown(joyStick + "Jump")){
            jumping = true;
        } else if(Input.GetButtonUp("Jump") || Input.GetButtonUp(joyStick + "Jump")){
            jumping = false;
        }
    }

    private void FixedUpdate() {
        if(playerOnMud){
            y_offset = Mathf.SmoothDamp(y_offset, -sink_distance, ref damp_ref, 3.0f);
            colliderTrans.position = new Vector3(colliderTrans.position.x, y_origin + y_offset, colliderTrans.position.z);
        }else{
            y_offset = Mathf.SmoothDamp(y_offset, 0, ref damp_ref, 1.0f);
            colliderTrans.position = new Vector3(colliderTrans.position.x, y_origin + y_offset, colliderTrans.position.z);
        }
    }

    public void setPlayerOnMud(){
        playerOnMud = true;
    }

    public void resetPlayerOnMud(){
        playerOnMud = false;
    }
}
