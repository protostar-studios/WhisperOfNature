using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class beeScript : MonoBehaviour
{
    private SeasonManager seasonManager;
    public int curSeason = 0;
    public GameObject beehiveModel;
    private GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        curSeason = seasonManager.curSeason;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        updateBee();
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonManager.curSeason != curSeason)
        {
            curSeason = seasonManager.curSeason;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            updateBee();
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
