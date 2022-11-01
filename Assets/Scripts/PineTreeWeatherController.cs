using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineTreeWeatherController : MonoBehaviour
{
    // Start is called before the first frame update
    private SeasonManager seasonManager;
    public GameObject PineTreeWinter;
    public GameObject pineTree;

    public int curSeason = 0;
    private GameObject child;
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        curSeason = seasonManager.curSeason;
        Object.Destroy(gameObject.transform.GetChild(0).gameObject);
        updatePineTree();
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonManager.curSeason != curSeason)
        {
            curSeason = seasonManager.curSeason;
            Object.Destroy(gameObject.transform.GetChild(0).gameObject);
            updatePineTree();
        }
    }

    void updatePineTree()
    {

        if (curSeason == 3)
        {
            child = Instantiate(PineTreeWinter) as GameObject;
            child.transform.position = gameObject.transform.position;
            child.transform.rotation = gameObject.transform.rotation;
            child.transform.localScale = gameObject.transform.localScale;
            child.transform.parent = gameObject.transform;
        }
        else 
        {
            child = Instantiate(pineTree) as GameObject;
            child.transform.position = gameObject.transform.position;
            child.transform.rotation = gameObject.transform.rotation;
            child.transform.localScale = gameObject.transform.localScale;
            child.transform.parent = gameObject.transform;
        }
    }

}
