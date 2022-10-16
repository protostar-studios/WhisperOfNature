using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<string, int> inventory = new Dictionary<string, int>();
    private Collider playerCollider;
    private bool collecting = false;
    public bool inBound = false;
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
        collecting = false;
        if(Input.GetButton("Collect")){
            collecting = true;
        }
    }
    
    private void FixedUpdate() {
        if(collecting && inBound && otherObject != null && inventory.ContainsKey(otherObject.tag)){
            inventory[otherObject.tag] += 1;
            Destroy(otherObject);
        }
    }
}
