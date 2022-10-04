using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGround : MonoBehaviour
{

    // public Material Summer_Floor_tile;
    // public Material Winter_Floor_tile;
    public int materialOrder = 1;
    private float changeSpeed;
    private SeasonManager seasonManager;
    private Material mat;
    private float opac;

    bool frozen = false;

    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        mat = GetComponent<Renderer>().materials[materialOrder];
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonManager.curSeason == 3){
            opac = Mathf.SmoothDamp(mat.GetFloat("_SnowOpacity"), 1, ref changeSpeed, 0.5f, 3.0f);
            mat.SetFloat("_SnowOpacity", opac);
        }
        else{
            opac = Mathf.SmoothDamp(mat.GetFloat("_SnowOpacity"), 0, ref changeSpeed, 0.5f, 3.0f);
            mat.SetFloat("_SnowOpacity", opac);
        }
    }
}
