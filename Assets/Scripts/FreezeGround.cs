using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGround : MonoBehaviour
{

    // public Material Summer_Floor_tile;
    // public Material Winter_Floor_tile;
    public int materialOrder = 1;
    private float changeSpeed;
    private float changeSpring;
    private float changeSummer;
    private float changeAutumn;
    private float changeWinter;
    private SeasonManager seasonManager;
    private Material mat;
    private float opac;
    public float spring = 1.0f;
    public float summer = 0.0f;
    public float autumn = 0.0f;
    public float winter = 0.0f;

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
        // Set snow
        if (seasonManager.curSeason == 3){
            opac = Mathf.SmoothDamp(mat.GetFloat("_SnowOpacity"), 0.7f, ref changeSpeed, 0.5f, 3.0f);
            mat.SetFloat("_SnowOpacity", opac);
        }
        else{
            opac = Mathf.SmoothDamp(mat.GetFloat("_SnowOpacity"), 0, ref changeSpeed, 0.5f, 3.0f);
            mat.SetFloat("_SnowOpacity", opac);
        }


        // Set ground
        if (seasonManager.curSeason == 3){
            winter = Mathf.SmoothDamp(mat.GetFloat("_Winter"), 1, ref changeSpring, 0.5f, 3.0f);
            spring = Mathf.SmoothDamp(mat.GetFloat("_Spring"), 0, ref changeSummer, 0.5f, 3.0f);
            summer = Mathf.SmoothDamp(mat.GetFloat("_Summer"), 0, ref changeAutumn, 0.5f, 3.0f);
            autumn = Mathf.SmoothDamp(mat.GetFloat("_Autumn"), 0, ref changeWinter, 0.5f, 3.0f);
            mat.SetFloat("_Winter", winter);
            mat.SetFloat("_Spring", spring);
            mat.SetFloat("_Summer", summer);
            mat.SetFloat("_Autumn", autumn);
        } else if(seasonManager.curSeason == 0){
            winter = Mathf.SmoothDamp(mat.GetFloat("_Winter"), 0, ref changeSpring, 0.5f, 3.0f);
            spring = Mathf.SmoothDamp(mat.GetFloat("_Spring"), 1, ref changeSummer, 0.5f, 3.0f);
            summer = Mathf.SmoothDamp(mat.GetFloat("_Summer"), 0, ref changeAutumn, 0.5f, 3.0f);
            autumn = Mathf.SmoothDamp(mat.GetFloat("_Autumn"), 0, ref changeWinter, 0.5f, 3.0f);
            mat.SetFloat("_Winter", winter);
            mat.SetFloat("_Spring", spring);
            mat.SetFloat("_Summer", summer);
            mat.SetFloat("_Autumn", autumn);
        } else if(seasonManager.curSeason == 1){
            winter = Mathf.SmoothDamp(mat.GetFloat("_Winter"), 0, ref changeSpring, 0.5f, 3.0f);
            spring = Mathf.SmoothDamp(mat.GetFloat("_Spring"), 0, ref changeSummer, 0.5f, 3.0f);
            summer = Mathf.SmoothDamp(mat.GetFloat("_Summer"), 1, ref changeAutumn, 0.5f, 3.0f);
            autumn = Mathf.SmoothDamp(mat.GetFloat("_Autumn"), 0, ref changeWinter, 0.5f, 3.0f);
            mat.SetFloat("_Winter", winter);
            mat.SetFloat("_Spring", spring);
            mat.SetFloat("_Summer", summer);
            mat.SetFloat("_Autumn", autumn);
        } else {
            winter = Mathf.SmoothDamp(mat.GetFloat("_Winter"), 0, ref changeSpring, 0.5f, 3.0f);
            spring = Mathf.SmoothDamp(mat.GetFloat("_Spring"), 0, ref changeSummer, 0.5f, 3.0f);
            summer = Mathf.SmoothDamp(mat.GetFloat("_Summer"), 0, ref changeAutumn, 0.5f, 3.0f);
            autumn = Mathf.SmoothDamp(mat.GetFloat("_Autumn"), 1, ref changeWinter, 0.5f, 3.0f);
            mat.SetFloat("_Winter", winter);
            mat.SetFloat("_Spring", spring);
            mat.SetFloat("_Summer", summer);
            mat.SetFloat("_Autumn", autumn);
        }
    }
}
