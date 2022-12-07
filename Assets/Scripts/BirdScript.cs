using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called before the first frame update
    private SeasonManager seasonManager;
    private MeshRenderer rend;
    private AudioSource audioSource;
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        rend = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        rend.enabled = true;
                
    }

    // Update is called once per frame
    void Update()
    {
         if (seasonManager.curSeason != 0)
        {
            rend.enabled = false;
            audioSource.volume = 0.0f;
        }
        else{
            rend.enabled = true;
            audioSource.volume = 1.0f;
        }
        
    }
}
