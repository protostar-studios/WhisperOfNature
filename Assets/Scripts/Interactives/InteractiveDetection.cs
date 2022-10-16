using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDetection: MonoBehaviour
{
    private PlayerManager playerManager;
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerStay(Collider other) {
        playerManager.inBound = true;
        playerManager.otherObject = this.gameObject;
    }

    private void OnTriggerExit(Collider other) {
        playerManager.inBound = false;
        playerManager.otherObject = null;
    }
}
