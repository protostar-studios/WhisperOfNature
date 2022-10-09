using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTreeWeatherController : MonoBehaviour
{
    // Start is called before the first frame update
    private SeasonManager seasonManager;
    public GameObject bigTreeSummer;
    public GameObject bigTreeWinter;
    public GameObject bigTreeSpring;
    public GameObject bigTreeFall;
    public int curSeason = 0;
    private GameObject child;
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        curSeason = seasonManager.curSeason;
        Object.Destroy(gameObject.transform.GetChild(0).gameObject);
        updateTree();
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonManager.curSeason != curSeason)
        {
            curSeason = seasonManager.curSeason;
            Object.Destroy(gameObject.transform.GetChild(0).gameObject);
            updateTree();
        }
    }

    void updateTree()
    {
        if (curSeason == 0)
        {
            child = Instantiate(bigTreeSpring) as GameObject;
            child.transform.position = gameObject.transform.position;
            child.transform.rotation = gameObject.transform.rotation;
            child.transform.localScale = gameObject.transform.localScale;
            child.transform.parent = gameObject.transform;
        }
        else if (curSeason == 3)
        {
            child = Instantiate(bigTreeWinter) as GameObject;
            child.transform.position = gameObject.transform.position;
            child.transform.rotation = gameObject.transform.rotation;
            child.transform.localScale = gameObject.transform.localScale;
            child.transform.parent = gameObject.transform;
        }
        else if (curSeason == 1)
        {
            child = Instantiate(bigTreeSummer) as GameObject;
            child.transform.position = gameObject.transform.position;
            child.transform.rotation = gameObject.transform.rotation;
            child.transform.localScale = gameObject.transform.localScale;
            child.transform.parent = gameObject.transform;
        }
        else if (curSeason == 2)
        {
            child = Instantiate(bigTreeFall) as GameObject;
            child.transform.position = gameObject.transform.position;
            child.transform.rotation = gameObject.transform.rotation;
            child.transform.localScale = gameObject.transform.localScale;
            child.transform.parent = gameObject.transform;
        }
    }

}
