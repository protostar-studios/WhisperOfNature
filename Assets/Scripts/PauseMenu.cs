using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject Canvas;
    public static bool paused = false;


    // Start is called before the first frame update
    void Start()
    {
        Canvas.gameObject.SetActive(false);
        paused = false;
    }
    public void SetPause(){
        if(paused == true){
            Canvas.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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
    
}
