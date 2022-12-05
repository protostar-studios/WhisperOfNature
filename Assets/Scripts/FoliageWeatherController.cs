using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FoliageWeatherController : MonoBehaviour
{
    // Start is called before the first frame update
    private SeasonManager seasonManager;
    public GameObject foliageSummer;
    public GameObject foliageWinter;
    public GameObject foliageSpring;
    public GameObject foliageAutumn;
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
        if(seasonManager.curSeason != curSeason){
            curSeason = seasonManager.curSeason;
            Object.Destroy(gameObject.transform.GetChild(0).gameObject);
            updateTree();
        }
    }

    void updateTree(){
        if(curSeason == 0){
            child = Instantiate(foliageSpring) as GameObject;
            child.transform.position = gameObject.transform.position;
            child.transform.rotation = gameObject.transform.rotation;
            child.transform.localScale = gameObject.transform.localScale;
            child.transform.parent = gameObject.transform;
        } else if (curSeason == 3){
            child = Instantiate(foliageWinter) as GameObject;
            child.transform.position = gameObject.transform.position;
            child.transform.rotation = gameObject.transform.rotation;
            child.transform.localScale = gameObject.transform.localScale;
            child.transform.parent = gameObject.transform;
        }
        else if (curSeason == 1)
        {
            child = Instantiate(foliageSummer) as GameObject;
            child.transform.position = gameObject.transform.position;
            child.transform.rotation = gameObject.transform.rotation;
            child.transform.localScale = gameObject.transform.localScale;
            child.transform.parent = gameObject.transform;
        }
        else if (curSeason == 2)
        {
            child = Instantiate(foliageAutumn) as GameObject;
            child.transform.position = gameObject.transform.position;
            child.transform.rotation = gameObject.transform.rotation;
            child.transform.localScale = gameObject.transform.localScale;
            child.transform.parent = gameObject.transform;
        }
    }

}
