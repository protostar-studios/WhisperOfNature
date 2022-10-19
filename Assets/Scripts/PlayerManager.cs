using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    // What the player has collected
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    private Collider playerCollider;

    // Used to detect player interactions
    private bool interacting = false;
    public bool inBound = false;

    // Leave it as null
    public GameObject otherObject = null;
    void Start()
    {
        playerCollider = gameObject.GetComponent<Collider>();
        setupInventory();
    }

    private void setupInventory(){
        inventory.Add("Seed", 0);
        inventory.Add("Gem", 0);
    }

    void Update()
    {
        interacting = false;
        if(Input.GetButton("Interact")){
            interacting = true;
        }
    }
    
    private void FixedUpdate() {
        // Check interaction
        if(interacting && inBound && otherObject != null){
            // Grab props
            if(inventory.ContainsKey(otherObject.tag)){
                inventory[otherObject.tag] += 1;
                Destroy(otherObject);
            }
            // Plant on soil
            if(otherObject.CompareTag("Soil")){
                if(inventory["Seed"] > 0){
                    SoilController soilCtrl = otherObject.GetComponent<SoilController>();
                    bool success = soilCtrl.Plant();
                    if(success){
                        inventory["Seed"] -= 1; 
                    }
                }
            }
        }
    }

}
