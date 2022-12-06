using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuUI : MonoBehaviour
{

    public EventSystem mainsys;
    public bool controllerDetected = false;
    public GameObject startButton;
    private PlayerInput playerInput;

    private void Awake() {
        playerInput = new PlayerInput();
    }

    private void OnEnable() {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }
    
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
        // feedback-adjusted with elias says no to this feature.

        if (!controllerDetected){
            // for (int i = 0;i < 20; i++) {
            //     if(Input.GetKeyDown("joystick 1 button "+i)){
            //         controllerDetected = true;
            //         EventSystem.current.SetSelectedGameObject(startButton);
            //         Debug.Log("joystick 1 button "+i);
            //     }
            // }

            // if(Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") < -0.1){
            //     controllerDetected = true;
            //     EventSystem.current.SetSelectedGameObject(startButton);
            // }

            // if(Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Vertical") < -0.1){
            //     controllerDetected = true;
            //     EventSystem.current.SetSelectedGameObject(startButton);
            // }

            // if(Input.GetAxis("Xbox_LookX") > 0.1 || Input.GetAxis("Xbox_LookX") < -0.1){
            //     controllerDetected = true;
            //     EventSystem.current.SetSelectedGameObject(startButton);
            // }

            // if(Input.GetAxis("Xbox_LookY") > 0.1 || Input.GetAxis("Xbox_LookY") < -0.1){
            //     controllerDetected = true;
            //     EventSystem.current.SetSelectedGameObject(startButton);
            // }
            Vector2 navigate_input = playerInput.UI.Navigate.ReadValue<Vector2>();
            // Debug.Log(navigate_input);
            if(navigate_input.y > 0.1 || navigate_input.y < -0.1){
                controllerDetected = true;
                EventSystem.current.SetSelectedGameObject(startButton);
            }
        }

    }
}
