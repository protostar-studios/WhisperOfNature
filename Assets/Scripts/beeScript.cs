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
    private Animator beeAnim;
    private GameObject beeCloud1;
    private GameObject beeCloud2;
    private GameObject beeCloud3;
    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        curSeason = seasonManager.curSeason;
        player = GameObject.FindWithTag("Player");
        collider = GetComponent<BoxCollider>();
        beeAnim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        beeCloud1 = gameObject.transform.GetChild(0).gameObject;//.GetComponent<SkinnedMeshRenderer>();
        // beeCloud2 = gameObject.transform.GetChild(1).gameObject;//.GetComponent<SkinnedMeshRenderer>();
        // beeCloud3 = gameObject.transform.GetChild(2).gameObject;//.GetComponent<SkinnedMeshRenderer>();
        // beeCloud.enabled = false;
        // if(transform.childCount != 0){
            // gameObject.transform.GetChild(0).gameObject.SetActive(false);
        // }
        updateBee();
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonManager.curSeason != 1)
        {
            collider.enabled = false;
            gameObject.tag = "Untagged";
            beeAnim.SetBool("isSummer", false);
            beeCloud1.SetActive(false);
        //     beeCloud2.SetActive(false);
        //     beeCloud3.SetActive(false);
        }
        else{
            collider.enabled = true;
            // gameObject.tag = "harmfulobj";
            beeAnim.SetBool("isSummer", true);
            // beeCloud.enabled = true;
            beeCloud1.SetActive(true);
            // beeCloud2.SetActive(true);
            // beeCloud3.SetActive(true);
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
