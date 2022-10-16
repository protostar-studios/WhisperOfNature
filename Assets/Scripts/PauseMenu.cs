using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject Canvas;
    bool paused = false;


    // Start is called before the first frame update
    void Start()
    {
        Canvas.gameObject.SetActive(false);
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
            if(paused == true){
                Canvas.gameObject.SetActive(false);
                Time.timeScale = 1.0f;
                paused = false;
            }
            else{
                Canvas.gameObject.SetActive(true);
                Time.timeScale = 0.0f;
                paused = true;
            }
        }
    }

    public void Resume(){
        Debug.Log("paused");
        Debug.Log("clicked");
        Canvas.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        paused = false;
    }

    public void Home(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
    
}
