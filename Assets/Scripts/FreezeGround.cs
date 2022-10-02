using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGround : MonoBehaviour
{

    public Material Summer_Floor_tile;
    public Material Winter_Floor_tile;
    private SeasonManager seasonManager;

    bool frozen = false;

    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonManager.curSeason == 3){
            GetComponent<Renderer>().material = Winter_Floor_tile;
        }
        else{
            GetComponent<Renderer>().material = Summer_Floor_tile;
        }
    }
}
