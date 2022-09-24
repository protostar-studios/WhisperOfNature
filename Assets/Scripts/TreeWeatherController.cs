using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeWeatherController : MonoBehaviour
{
    // Start is called before the first frame update
    public WeatherManager weatherManager;
    public GameObject treeSummer;
    public GameObject treeWinter;
    public int curWeather = 0;
    private GameObject child;
    void Start()
    {
        curWeather = weatherManager.curWeather;
        updateTree();
    }

    // Update is called once per frame
    void Update()
    {
        if(weatherManager.curWeather != curWeather){
            curWeather = weatherManager.curWeather;
            Object.Destroy(gameObject.transform.GetChild(0).gameObject);
            updateTree();
        }
    }

    void updateTree(){
        if(curWeather == 0){
            child = Instantiate(treeSummer) as GameObject;
            child.transform.parent = gameObject.transform;
        } else if (curWeather == 1){
            child = Instantiate(treeWinter) as GameObject;
            child.transform.parent = gameObject.transform;
        }
    }

}
