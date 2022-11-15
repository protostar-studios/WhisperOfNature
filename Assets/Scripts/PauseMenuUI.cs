using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuUI : MonoBehaviour
{

    public EventSystem pausemenusys;
    public bool controllerDetected = false;
    public GameObject resumeButton;

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
            if (!controllerDetected){
                for (int i = 0;i < 20; i++) {
                    if(Input.GetKeyDown("joystick 1 button "+i)){
                        controllerDetected = true;
                        EventSystem.current.SetSelectedGameObject(resumeButton);
                        Debug.Log("joystick 1 button "+i);
                    }
                }

            if(Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") < -0.1){
                controllerDetected = true;
                EventSystem.current.SetSelectedGameObject(resumeButton);
            }

            if(Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Vertical") < -0.1){
                controllerDetected = true;
                EventSystem.current.SetSelectedGameObject(resumeButton);
            }

            if(Input.GetAxis("Xbox_LookX") > 0.1 || Input.GetAxis("Xbox_LookX") < -0.1){
                controllerDetected = true;
                EventSystem.current.SetSelectedGameObject(resumeButton);
            }

            if(Input.GetAxis("Xbox_LookY") > 0.1 || Input.GetAxis("Xbox_LookY") < -0.1){
                controllerDetected = true;
                EventSystem.current.SetSelectedGameObject(resumeButton);
            }
        }

        // else{
        //     controllerDetected = false;
        //     EventSystem.current.SetSelectedGameObject(gameObject);
        // }
        // if(Input.GetAxis("Mouse X") > 0.1 && Input.GetAxis("Mouse X") < -0.1){
        //     Debug.Log("aha");
        // }

        // if(Input.GetAxis("Mouse Y") > 0){
        //     Debug.Log("ahaa");
        // }
        }
    }
}
