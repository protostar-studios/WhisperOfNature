using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThornyBush : MonoBehaviour
{
    private SeasonManager seasonManager;
    private BoxCollider thornTrigger;
    private int curSeason;
    private GameObject currentActive;
    public bool damaging;
    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        thornTrigger = GetComponent<BoxCollider>();
        curSeason = seasonManager.curSeason;
        currentActive = this.transform.Find("Alive").gameObject;
        if(currentActive == null){
            Debug.Log("cant find active");
        }
        else{
            Debug.Log(currentActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonManager.curSeason != 2){
            thornTrigger.enabled = false;
        }
        else{
            // Debug.Log("Fall! Trigger enabled");
            if(damaging){
                thornTrigger.enabled = true;
            }
            
        }
        if (curSeason != seasonManager.curSeason){
            currentActive.SetActive(false);
            switch(seasonManager.curSeason)
            {
                case 0:
                    currentActive = this.transform.Find("Alive").gameObject;
                    break;
                case 1:
                    currentActive = this.transform.Find("Alive").gameObject;
                    break;
                case 2:
                    if(damaging){
                        currentActive = this.transform.Find("Dead").gameObject;
                    }
                    else{
                        currentActive = this.transform.Find("Autumn").gameObject;
                    }
                    break;
                case 3:
                    currentActive = this.transform.Find("Winter").gameObject;
                    break;
            }
            if(currentActive != null){
                currentActive.SetActive(true);
            }
        }

    }
}
