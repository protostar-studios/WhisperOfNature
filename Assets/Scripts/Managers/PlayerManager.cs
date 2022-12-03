using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    // What the player has collected
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    Collider playerCollider;
    PlayerMainController playerMainController;
    PlayerInput playerInput;
    public int[] inv = new int[2];
    // Used to detect player interactions
    bool interacting = false;
    public bool inBound = false;

    // Leave it as null
    public GameObject otherObject = null;
    // string joyStick = "PS_";

    private void Awake() {
        playerInput = new PlayerInput();
    }
    private void OnEnable() {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }
    void Start()
    {
        playerCollider = gameObject.GetComponent<Collider>();
        playerMainController = GetComponent<PlayerMainController>();
        setupInventory();
        // joyStick = FindObjectOfType<JoyStickManager>().joyStick;
    }

    private void setupInventory(){
        inventory.Add("Seed", 0);
        inventory.Add("Gem", 0);
    }

    void Update()
    {
        Debug.Log("Gem" + inventory["Gem"]);
        interacting = false;
        // if(Input.GetButton("Interact") || Input.GetButton(joyStick + "Interact")){
        //     interacting = true;
        // }
        if(playerInput.Player.Interact.triggered){
            interacting = true;
        }

        // Pause
        // if(Input.GetButtonDown("Quit") || Input.GetButtonDown(joyStick + "Quit")){
        if(playerInput.Player.Quit.triggered){
            try{
                if(PauseMenu.died == false)
                {
                    FindObjectOfType<PauseMenu>().SetPause();
                }
            }catch (System.Exception){
                Debug.Log("Please add Pause Menu Object to the scene");
            }
        }
    }
    
    private void FixedUpdate() {
        // Check interaction
        if(inBound && otherObject != null){
            // Grab props
            if(inventory.ContainsKey(otherObject.tag)){
                inventory[otherObject.tag] += 1;
                playerMainController.setAnimBool("pickingup");
                Destroy(otherObject);
            }
            // Plant on soil
            if(interacting && otherObject.CompareTag("Soil")){
                if(inventory["Seed"] > 0){
                    SoilController soilCtrl = otherObject.GetComponent<SoilController>();
                    bool success = soilCtrl.Plant();
                    if(success){
                        playerMainController.setAnimBool("planting");
                        inventory["Seed"] -= 1; 
                    }
                }
            }
        }
    }

}
