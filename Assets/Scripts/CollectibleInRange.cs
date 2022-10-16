using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleInRange : MonoBehaviour
{
    private PlayerInventory playerInv;
    void Start()
    {
        playerInv = FindObjectOfType<PlayerInventory>();
    }

    private void OnTriggerStay(Collider other) {
        playerInv.inBound = true;
        playerInv.otherObject = this.gameObject;
    }

    private void OnTriggerExit(Collider other) {
        playerInv.inBound = false;
        playerInv.otherObject = null;
    }
}
