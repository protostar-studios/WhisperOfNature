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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        // The mouse is locked somewhere in another script that made the click
        // not actualy 'click' the button.
        // Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
            if(paused == true){
                Canvas.gameObject.SetActive(false);
                Time.timeScale = 1.0f;
                paused = false;
                Cursor.visible = false;
            }
            else{
                Canvas.gameObject.SetActive(true);
                Time.timeScale = 0.0f;
                paused = true;
                Cursor.visible = true;
            }
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
