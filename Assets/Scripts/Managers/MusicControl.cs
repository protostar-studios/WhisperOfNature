using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private SeasonManager seasonManager;

    public AudioSource backgroundMusic;
    public AudioClip summerMusic;
    public AudioClip springMusic;
    public AudioClip autumnMusic;
    public AudioClip winterMusic;
    private int curSeason;

    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        curSeason = seasonManager.curSeason;
    }

    // Update is called once per frame
    void Update()
    {
        // switch (seasonManager.curSeason)
        if(seasonManager.curSeason != curSeason){
            backgroundMusic.Stop();
            if(seasonManager.curSeason == 0){
                backgroundMusic.clip = springMusic;
            } else if (seasonManager.curSeason == 1){
                backgroundMusic.clip = summerMusic;
            } else if (seasonManager.curSeason == 2){
                backgroundMusic.clip = autumnMusic;
            } else {
                backgroundMusic.clip = winterMusic;
            }
            curSeason = seasonManager.curSeason;
            backgroundMusic.Play();
        }

        // THE PROBLEM WITH SWITCH IS THAT MUSIC CONTINUOUSLY REPEATS EVERY FRAME
        // SHOULD SWITCH MUSIC ONLY ON BUTTON PRESS NOT ON EVERY FRAME

        /*switch (seasonManager.curWeather)
        {
            case 1:
                backgroundMusic.clip = summerMusic;
                backgroundMusic.Play();
                break;
            case 2:
                backgroundMusic.clip = summerMusic;
                backgroundMusic.Play();
                break;
            default:
                backgroundMusic.clip = summerMusic;
                backgroundMusic.Play();
                break; 
        }*/
    }
}
