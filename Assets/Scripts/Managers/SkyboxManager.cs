using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public Material autumnSkybox;

    public Material winterSkybox;

    public Material springSkybox;

    public Material summerSkybox;
    private SeasonManager seasonManager;

    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonManager.curSeason == 0)
        {
            RenderSettings.skybox = springSkybox;
        }
        else if (seasonManager.curSeason == 1)
        {
            RenderSettings.skybox = summerSkybox;
        }
        else if(seasonManager.curSeason == 2)
        {
            RenderSettings.skybox = autumnSkybox;
        } 
        else if (seasonManager.curSeason == 3)
        {
            RenderSettings.skybox = winterSkybox;
        }


    }
}
