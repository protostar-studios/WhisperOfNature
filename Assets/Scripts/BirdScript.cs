using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called before the first frame update
    private SeasonManager seasonManager;
    private MeshRenderer rend;
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        rend = GetComponent<MeshRenderer>();
        rend.enabled = true;
                
    }

    // Update is called once per frame
    void Update()
    {
         if (seasonManager.curSeason != 0)
        {
            rend.enabled = false;
        }
        else{
            rend.enabled = true;
        }
        
    }
}
