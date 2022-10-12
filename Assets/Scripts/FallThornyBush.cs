using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThornyBush : MonoBehaviour
{
    private SeasonManager seasonManager;
    private BoxCollider thornTrigger;
    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        thornTrigger = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonManager.curSeason != 2){
            thornTrigger.enabled = false;
        }
        else{
            // Debug.Log("Fall! Trigger enabled");
            thornTrigger.enabled = true;
        }
    }
}
