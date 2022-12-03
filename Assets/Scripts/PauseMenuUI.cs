using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuUI : MonoBehaviour
{

    public EventSystem pausemenusys;
    public bool controllerDetected = false;
    public GameObject resumeButton;
    private PlayerInput playerInput;

    private void Awake() {
        playerInput = new PlayerInput();
    }

    // Start is called before the first frame update
    void Start()
    {   
        pausemenusys = EventSystem.current;
        // mainsys.setSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {   
        if (PauseMenu.paused){
            if(!playerInput.UI.enabled){
                playerInput.Player.Disable();
                playerInput.UI.Enable();
            }
            if (!controllerDetected){
                // for (int i = 0;i < 20; i++) {
                //     if(Input.GetKeyDown("joystick 1 button "+i) && i!=7){
                //         // Debug.Log(i);
                //         controllerDetected = true;
                //         EventSystem.current.SetSelectedGameObject(resumeButton);
                //         Debug.Log("joystick 1 button "+i);
                //     }
                // }
                Vector2 navigate_input = playerInput.UI.Navigate.ReadValue<Vector2>();
                Debug.Log(navigate_input);
                if(navigate_input.y > 0.1 || navigate_input.y < -0.1){
                    controllerDetected = true;
                    EventSystem.current.SetSelectedGameObject(resumeButton);
                }
            }
        }
        else{
            playerInput.Player.Enable();
            playerInput.UI.Disable();
            controllerDetected = false;
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }
}
