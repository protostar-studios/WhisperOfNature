using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeWater : MonoBehaviour
{
    // Start is called before the first frame update
    private float changeSpeed;
    private SeasonManager seasonManager;
    private Material mat;
    private float opac;

    bool frozen = false;
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonManager.curSeason == 3){
            GetComponent<Collider>().enabled = true;
            opac = Mathf.SmoothDamp(mat.GetFloat("_iceLevel"), 0.8f, ref changeSpeed, 0.5f, 3.0f);
            mat.SetFloat("_iceLevel", opac);
            mat.SetFloat("_waterSpeed", 1 - opac);
        } else{
            GetComponent<Collider>().enabled = false;
            opac = Mathf.SmoothDamp(mat.GetFloat("_iceLevel"), 0, ref changeSpeed, 0.5f, 3.0f);
            mat.SetFloat("_iceLevel", opac);
            mat.SetFloat("_waterSpeed", 1 - opac);
        }

        if(seasonManager.curSeason == 1){
            
        }

    }
}
