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
    public float MIN_ANGLE = -50f;

    public float sensitivity = 0.2f;
    private float LookX = 0.0f;
    private float LookY = 0.0f;

    private string Joystick = "PS_";
    private PlayerInput playerInput;

    float lookx_cal = 0.0f;
    float looky_cal = 0.0f;

    private void Awake() {
        playerInput = new PlayerInput();
    }

    void Start()
    {
        // xMove = transform.rotation.eulerAngles.x;
        xMove = transform.rotation.eulerAngles.y;
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        transform.position = transform.rotation * negDistance;
        transform.rotation = camTarget.transform.rotation;
        transform.LookAt(camTarget.transform);
        Vector2 look = playerInput.Player.Look.ReadValue<Vector2>();
        lookx_cal = look.x;
        looky_cal = look.y;

        // Joystick Detection
        Joystick = FindObjectOfType<JoyStickManager>().joyStick;
    }
    
    public void ChangeTarget(GameObject newModel)
    {
        camTarget = newModel;
    }
    private void OnEnable() {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        if(!RespawnMenu.died && !PauseMenu.paused){
            // xMove += (Input.GetAxis("Mouse X") + sensitivity * Input.GetAxis(Joystick + "LookX"));
            // yMove += (-Input.GetAxis("Mouse Y") + sensitivity * Input.GetAxis(Joystick + "LookY"));
            Vector2 look = playerInput.Player.Look.ReadValue<Vector2>();
            xMove += look.x * sensitivity;
            yMove += look.y * sensitivity;
        }
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
