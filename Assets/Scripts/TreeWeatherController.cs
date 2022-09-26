using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeWeatherController : MonoBehaviour
{
    // Start is called before the first frame update
    private SeasonManager seasonManager;
    public GameObject treeSummer;
    public GameObject treeWinter;
    public int curWeather = 0;
    private GameObject child;
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        curWeather = seasonManager.curWeather;
        Object.Destroy(gameObject.transform.GetChild(0).gameObject);
        updateTree();
    }

    // Update is called once per frame
    void Update()
    {
        if(seasonManager.curWeather != curWeather){
            curWeather = seasonManager.curWeather;
            Object.Destroy(gameObject.transform.GetChild(0).gameObject);
            updateTree();
        }
    }

    void updateTree(){
        if(curWeather == 0){
            child = Instantiate(treeSummer) as GameObject;
            child.transform.position = gameObject.transform.position;
            child.transform.parent = gameObject.transform;
        } else if (curWeather == 1){
            child = Instantiate(treeWinter) as GameObject;
            child.transform.position = gameObject.transform.position;
            child.transform.parent = gameObject.transform;
        }
    }

}
