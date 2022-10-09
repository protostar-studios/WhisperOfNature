using System.Collections.Generic;
using UnityEngine;

public class SeasonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int curSeason = 0;
    public List<string> seasons = new List<string>(){"spring", "summer", "fall", "winter"};
    public bool rain = true;
    public GameObject snowParticles;
    public Vector3 snowPos;
    public Vector3 snowRot;
    private bool isSnowing = false;
    private GameObject snow = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Spring
        if(Input.GetButtonDown("Num1")){
            curSeason = 0;
            if(isSnowing){
                snow.GetComponent<ParticleSystem>().Stop();
                isSnowing = false;
            }
            rain = true;
        }
        // Summer
        if(Input.GetButtonDown("Num2")){
            curSeason = 1;
            if(isSnowing){
                snow.GetComponent<ParticleSystem>().Stop();
                isSnowing = false;
            }
            rain = false;
        }

        // Fall
        if(Input.GetButtonDown("Num3")){
            curSeason = 2;
            if(isSnowing){
                snow.GetComponent<ParticleSystem>().Stop();
                isSnowing = false;
            }
            rain = false;
        }

        // Winter
        if(Input.GetButtonDown("Num4")){
            curSeason = 3;
            if(snow == null){
                snow = GameObject.Instantiate(snowParticles, snowPos, Quaternion.Euler(snowRot));
            }
            snow.GetComponent<ParticleSystem>().Play();
            isSnowing = true;
            rain = false;
        }
    }

}
