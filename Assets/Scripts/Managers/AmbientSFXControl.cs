using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSFXControl : MonoBehaviour
{
    public AudioClip[] ambientSFX = {null, null, null, null};
    public float[] ambientVolumes = {1, 1, 1, 1};

    private int curSeason;
    private AudioSource audioSource;
    private SeasonManager seasonManager;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        seasonManager = FindObjectOfType<SeasonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(seasonManager.curSeason != curSeason){
            audioSource.Stop();
            audioSource.clip = ambientSFX[seasonManager.curSeason];
            audioSource.volume = ambientVolumes[seasonManager.curSeason];
            audioSource.Play();
            curSeason = seasonManager.curSeason;
        }
    }
}
