using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int curWeather = 0;
    public List<string> weathers = new List<string>(){"summer", "winter"};
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Summer
        if(Input.GetButtonDown("Num1")){
            curWeather = 0;
        }
        // Winter
        if(Input.GetButtonDown("Num2")){
            curWeather = 1;
        }
    }

}
