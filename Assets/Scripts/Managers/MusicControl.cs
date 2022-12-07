using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private SeasonManager seasonManager;

    public AudioSource[] backgroundMusic;
    public AudioClip[] Musics;
    private int curSeason;

    private float volumeSpring = 0.0f;
    private float volumeSummer = 0.0f;
    private float volumeAutumn = 0.0f;
    private float volumeWinter = 0.0f;

    float curVolSpr;
    float curVolSum;
    float curVolAut;
    float curVolWin;

    float volumnChangeSpeed = 0.5f;
    float MUSIC_ON_TARGET_VOL = 0.5f;

    float[] newVolumes; // Temp for volumes

    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        backgroundMusic = GetComponents<AudioSource>();
        curSeason = seasonManager.curSeason;

        // Init music clips
        for(int i=0; i < 4; i++){
            backgroundMusic[i].clip = Musics[i];
            if(curSeason == i){
                backgroundMusic[i].volume = MUSIC_ON_TARGET_VOL;
            }else{
                backgroundMusic[i].volume = 0;
            }
            backgroundMusic[i].Play();
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        // THE PROBLEM WITH SWITCH IS THAT MUSIC CONTINUOUSLY REPEATS EVERY FRAME
        // SHOULD SWITCH MUSIC ONLY ON BUTTON PRESS NOT ON EVERY FRAME

        switch (seasonManager.curSeason)
            {
                case 0: // Spring
                    volumeSpring = Mathf.SmoothDamp(volumeSpring, MUSIC_ON_TARGET_VOL, ref curVolSpr, volumnChangeSpeed);
                    volumeSummer = Mathf.SmoothDamp(volumeSummer, 0, ref curVolSum, volumnChangeSpeed);
                    volumeAutumn = Mathf.SmoothDamp(volumeAutumn, 0, ref curVolAut, volumnChangeSpeed);
                    volumeWinter = Mathf.SmoothDamp(volumeWinter, 0, ref curVolWin, volumnChangeSpeed);
                    newVolumes = new float[] {volumeSpring, volumeSummer, volumeAutumn, volumeWinter};
                    for (int i=0;i<4;i++){
                        backgroundMusic[i].volume = newVolumes[i];
                    }
                    break;
                case 1:
                    volumeSpring = Mathf.SmoothDamp(volumeSpring, 0, ref curVolSpr, volumnChangeSpeed);
                    volumeSummer = Mathf.SmoothDamp(volumeSummer, MUSIC_ON_TARGET_VOL, ref curVolSum, volumnChangeSpeed);
                    volumeAutumn = Mathf.SmoothDamp(volumeAutumn, 0, ref curVolAut, volumnChangeSpeed);
                    volumeWinter = Mathf.SmoothDamp(volumeWinter, 0, ref curVolWin, volumnChangeSpeed);
                    newVolumes = new float[] {volumeSpring, volumeSummer, volumeAutumn, volumeWinter};
                    for (int i=0;i<4;i++){
                        backgroundMusic[i].volume = newVolumes[i];
                    }
                    break;
                case 2:
                    volumeSpring = Mathf.SmoothDamp(volumeSpring, 0, ref curVolSpr, volumnChangeSpeed);
                    volumeSummer = Mathf.SmoothDamp(volumeSummer, 0, ref curVolSum, volumnChangeSpeed);
                    volumeAutumn = Mathf.SmoothDamp(volumeAutumn, MUSIC_ON_TARGET_VOL, ref curVolAut, volumnChangeSpeed);
                    volumeWinter = Mathf.SmoothDamp(volumeWinter, 0, ref curVolWin, volumnChangeSpeed);
                    newVolumes = new float[] {volumeSpring, volumeSummer, volumeAutumn, volumeWinter};
                    for (int i=0;i<4;i++){
                        backgroundMusic[i].volume = newVolumes[i];
                    }
                    break;
                case 3:
                    volumeSpring = Mathf.SmoothDamp(volumeSpring, 0, ref curVolSpr, volumnChangeSpeed);
                    volumeSummer = Mathf.SmoothDamp(volumeSummer, 0, ref curVolSum, volumnChangeSpeed);
                    volumeAutumn = Mathf.SmoothDamp(volumeAutumn, 0, ref curVolAut, volumnChangeSpeed);
                    volumeWinter = Mathf.SmoothDamp(volumeWinter, MUSIC_ON_TARGET_VOL, ref curVolWin, volumnChangeSpeed);
                    newVolumes = new float[] {volumeSpring, volumeSummer, volumeAutumn, volumeWinter};
                    for (int i=0;i<4;i++){
                        backgroundMusic[i].volume = newVolumes[i];
                    }
                    break;
                default:
                    break; 
            }
    }
}
