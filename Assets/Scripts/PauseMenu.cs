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

    public Image resumeButtonImage;

    public SpriteState respawnStates;

    public SpriteState resumeStates;

    public PlayerMainController pmc;

    // Start is called before the first frame update
    void Start()
    {
        Canvas.gameObject.SetActive(false);
        paused = false;

        respawnStates.pressedSprite = respawnSprites[2];
        respawnStates.highlightedSprite = respawnSprites[1];
        respawnStates.selectedSprite = respawnSprites[2];

        resumeStates.pressedSprite = resumeSprites[2];
        resumeStates.highlightedSprite = resumeSprites[1];
        resumeStates.selectedSprite = resumeSprites[2];
    }

    void Update()
    {
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
        if(paused == true){
            Canvas.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if(died == true){
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

    public void DisplayRespawn(){
        Canvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
        // died = true;
        Cursor.visible = true;
        statusText.sprite = perishedTextSprite;
    }
    
}
