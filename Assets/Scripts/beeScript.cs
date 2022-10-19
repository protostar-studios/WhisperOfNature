using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class beeScript : MonoBehaviour
{
    private SeasonManager seasonManager;
    public int curSeason = 0;
    // public GameObject beehiveModel;
    private GameObject child;

    public GameObject player;

    private Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        curSeason = seasonManager.curSeason;
        player = GameObject.FindWithTag("Player");
        collider = GetComponent<BoxCollider>();
        // if(transform.childCount != 0){
            // gameObject.transform.GetChild(0).gameObject.SetActive(false);
        // }
        updateBee();
    }

    // Update is called once per frame
    void Update()
    {
        // if (seasonManager.curSeason != curSeason)
        // {
        //     curSeason = seasonManager.curSeason;
        //     gameObject.transform.GetChild(0).gameObject.SetActive(false);
        //     updateBee();
        // }
        if (seasonManager.curSeason != 1)
        {
            // curSeason = seasonManager.curSeason;
            // gameObject.transform.GetChild(0).gameObject.SetActive(false);
            // updateBee();
            collider.enabled = false;
            gameObject.tag = "Untagged";
        }
        else{
            collider.enabled = true;
            gameObject.tag = "harmfulobj";
        }
        //Debug.Log(player.transform.position);
        checkNearPlayer();
    }

    void checkNearPlayer()
    {
        if ((gameObject.transform.position - player.transform.position).magnitude < 5.0f){
            Debug.Log("close");
        }
    }

    void updateBee()
    {
        if (curSeason == 1)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);


        }
    }
}
