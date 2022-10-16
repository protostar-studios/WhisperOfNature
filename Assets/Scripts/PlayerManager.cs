using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    // What the player has collected
    private Dictionary<string, int> inventory = new Dictionary<string, int>();
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
        if(interacting && inBound && otherObject != null && inventory.ContainsKey(otherObject.tag)){
            inventory[otherObject.tag] += 1;
            Destroy(otherObject);
        }
    }

}
