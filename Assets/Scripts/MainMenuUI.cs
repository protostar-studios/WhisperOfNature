using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuUI : MonoBehaviour
{

    public EventSystem mainsys;
    public bool controllerDetected = false;
    public GameObject startButton;

    // Start is called before the first frame update
    void Start()
    {   
        mainsys = EventSystem.current;
        // mainsys.setSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!controllerDetected){
            for (int i = 0;i < 20; i++) {
                if(Input.GetKeyDown("joystick 1 button "+i)){
                    controllerDetected = true;
                    EventSystem.current.SetSelectedGameObject(startButton);
                    Debug.Log("joystick 1 button "+i);
                }
            }

            if(Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") < -0.1){
                controllerDetected = true;
                EventSystem.current.SetSelectedGameObject(startButton);
            }

            if(Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Vertical") < -0.1){
                controllerDetected = true;
                EventSystem.current.SetSelectedGameObject(startButton);
            }

            if(Input.GetAxis("Xbox_LookX") > 0.1 || Input.GetAxis("Xbox_LookX") < -0.1){
                controllerDetected = true;
                EventSystem.current.SetSelectedGameObject(startButton);
            }

            if(Input.GetAxis("Xbox_LookY") > 0.1 || Input.GetAxis("Xbox_LookY") < -0.1){
                controllerDetected = true;
                EventSystem.current.SetSelectedGameObject(startButton);
            }
        }

    }
}
