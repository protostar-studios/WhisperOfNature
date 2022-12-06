using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHiveAudioScript : MonoBehaviour
{
    
    private SeasonManager seasonManager;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonManager.curSeason != 1)
        {
            audioSource.volume = 0.0f;
        }
        else{
            audioSource.volume = 0.1f;
        }
    }
}
