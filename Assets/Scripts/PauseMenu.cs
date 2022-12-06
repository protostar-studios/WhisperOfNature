using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject Canvas;
    public static bool paused = false;

    public static bool died = false;
    public Sprite pausedTextSprite;

    public Sprite perishedTextSprite;
    public Image statusText;

    public Sprite[] respawnSprites;

    public Sprite[] resumeSprites;
    public Button resumeButton;

    // public Button levelsButton;

    // public Button quitButton;

    public Image resumeButtonImage;

    public SpriteState respawnStates;

    public SpriteState resumeStates;

    public PlayerMainController pmc;

    public static int char_status = 0;

    public Image charStatusImage;

    public Sprite[] charStatusSprites;

    /*
    CHAR STATUS INT MAPPING:

    0 = paused;
    1 = drown fall;
    2 = drown spring;
    3 = drown summer;
    4 = drown winter;
    5 = thorn winter;
    6 = thorn fall;
    7 = bee summer;

    */ 

    void checkCharStatusImg(){

        // Debug.Log(died);
        // Debug.Log(char_status);
        if (!died){
            char_status = 0;
        }

        switch (char_status){
            case 0:
                charStatusImage.sprite = charStatusSprites[0];
                break;
            case 1:
                charStatusImage.sprite = charStatusSprites[1];
                break;
            case 2:
                charStatusImage.sprite = charStatusSprites[2];
                break;
            case 3:
                charStatusImage.sprite = charStatusSprites[3];
                break;
            case 4:
                charStatusImage.sprite = charStatusSprites[4];
                break;
            case 5:
                charStatusImage.sprite = charStatusSprites[5];
                break;
            case 6:
                charStatusImage.sprite = charStatusSprites[6];
                break;
            case 7:
                charStatusImage.sprite = charStatusSprites[7];
                break;
            default:
                charStatusImage.sprite = charStatusSprites[0];
                break;
        }
    }

    

    // Vector3 pausedResume;
    // Vector3 pausedLevels;
    // Vector3 pausedQuit;

    // void pausedPositions(){
    //     Vector3 pausedResume = resumeButton.transform.position;
    //     Vector3 pausedLevels = levelsButton.transform.position;
    //     Vector3 pausedQuit = quitButton.transform.position;

    //     pausedResume.x -= 320f;
    //     pausedResume.y -= 295f;
    //     pausedLevels.y -= 286f;
    //     pausedQuit.x += 307f;
    //     pausedQuit.y -= 87f;

    //     resumeButton.transform.position = pausedResume;
    //     levelsButton.transform.position = pausedLevels;
    //     quitButton.transform.position = pausedQuit;

    // }

    // void diedPositions(){
    //     Vector3 pausedResume = resumeButton.transform.position;
    //     Vector3 pausedLevels = levelsButton.transform.position;
    //     Vector3 pausedQuit = quitButton.transform.position;

    //     pausedResume.x += 320f;
    //     pausedResume.y += 295f;
    //     pausedLevels.y += 286f;
    //     pausedQuit.x -= 307f;
    //     pausedQuit.y += 87f;

    //     resumeButton.transform.position = pausedResume;
    //     levelsButton.transform.position = pausedLevels;
    //     quitButton.transform.position = pausedQuit;
    // }

    // Start is called before the first frame update
    void Start()
    {
        Canvas.gameObject.SetActive(false);
        paused = false;

        respawnStates.pressedSprite = respawnSprites[2];
        respawnStates.highlightedSprite = respawnSprites[1];
        respawnStates.selectedSprite = respawnSprites[1];

        resumeStates.pressedSprite = resumeSprites[2];
        resumeStates.highlightedSprite = resumeSprites[1];
        resumeStates.selectedSprite = resumeSprites[1];
        statusText.sprite = pausedTextSprite;

        // pausedResume = resumeButton.transform.position;
        // pausedLevels = levelsButton.transform.position;
        // pausedQuit = quitButton.transform.position;

    }

    void Update()
    {

        checkCharStatusImg();

        if(died == true){
            resumeButton.spriteState = respawnStates;
            statusText.sprite = perishedTextSprite;
            resumeButtonImage.sprite = respawnSprites[0];
        }
        else{
            statusText.sprite = pausedTextSprite;
            resumeButton.spriteState = resumeStates;
            resumeButtonImage.sprite = resumeSprites[0];
        }
    }
    public void SetPause(){
        if(died == false && paused == true){
            Debug.Log("paused");
            Canvas.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if(died == true){
            Debug.Log("died");
            Canvas.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            // The cursor is locked when playing the game but not in pause menu
            Time.timeScale = 0.0f;
            paused = true;
            Cursor.visible = true;
        }
        else{
            Canvas.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            // The cursor is locked when playing the game but not in pause menu
            Time.timeScale = 0.0f;
            paused = true;
            Cursor.visible = true;
        }

    }

    public void Resume(){
        if (died == true){
            try{
                pmc = (PlayerMainController)GameObject.Find("Guardian").GetComponent(typeof(PlayerMainController));
                pmc.Respawn();
            }
            catch(System.Exception){
                Debug.Log(pmc);
            }
            
            died = false;
        }
        
        Canvas.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        paused = false;
    }

    public void Home(){
        Time.timeScale = 1.0f;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }

    public void Levels(){
        Time.timeScale = 1.0f;
        Cursor.visible = true;
        SceneManager.LoadScene("LevelsMenu");
    }

    public void DisplayRespawn(){
        Canvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
        // died = true;
        Cursor.visible = true;
        statusText.sprite = perishedTextSprite;
    }
    
}
