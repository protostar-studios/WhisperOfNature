using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private SeasonManager seasonManager;

    public AudioSource backgroundMusic;
    public AudioClip summerMusic;
    public AudioClip winterMusic;

    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // switch (seasonManager.curSeason)
        if(Input.GetButtonDown("Num1")){
            backgroundMusic.Stop();
            backgroundMusic.clip = summerMusic;
            backgroundMusic.Play();
        }
        // Winter
        if(Input.GetButtonDown("Num4")){
            backgroundMusic.Stop();
            backgroundMusic.clip = winterMusic;
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
