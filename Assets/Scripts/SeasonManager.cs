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
        // Change seasons with two buttons.
        if(Input.GetButtonDown("PrevSeason")){
            if(curSeason - 1 < 0){
                curSeason = 3;
            }else{
                curSeason -= 1;
            }
        }

        if(Input.GetButtonDown("NextSeason")){
            if(curSeason + 1 > 3){
                curSeason = 0;
            }else{
                curSeason += 1;
            }
        }

        // Set snow
        if(curSeason == 3){
            isSnowing = true;
            if(snow == null){
                snow = GameObject.Instantiate(snowParticles, snowPos, Quaternion.Euler(snowRot));
            }
            snow.GetComponent<ParticleSystem>().Play();
        }else{
            if(isSnowing){
                snow.GetComponent<ParticleSystem>().Stop();
                isSnowing = false;
            }
        }

        if(curSeason == 0){
            rain = true;
        }else{
            rain = false;
        }
        
    }

}
