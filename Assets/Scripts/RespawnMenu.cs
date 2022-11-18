using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnMenu : MonoBehaviour
{

    public GameObject Canvas;
    public static bool died = false;
    public PlayerMainController pmc;

    // Start is called before the first frame update
    void Start()
    {
        Canvas.gameObject.SetActive(false);   
    }
    public void DisplayMenu(){
        Canvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
        died = true;
        Cursor.visible = true;
    }

    public void Respawn(){
        try{
            pmc = (PlayerMainController)GameObject.Find("Guardian").GetComponent(typeof(PlayerMainController));
            pmc.Respawn();
        }
        catch(System.Exception){
            Debug.Log(pmc);
        }
        
        Canvas.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        died = false;
    }
    
}
