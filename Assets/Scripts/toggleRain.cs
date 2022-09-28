using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleRain : MonoBehaviour
{
    private SeasonManager seasonManager;

    // Start is called before the first frame update
    void Start()
    {
         seasonManager = Object.FindObjectOfType<SeasonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonManager.rain == true){
            GetComponent<ParticleSystem>().Play();
        }
        else{
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
