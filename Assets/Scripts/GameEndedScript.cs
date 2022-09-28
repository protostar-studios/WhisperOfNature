using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameEndedScript : MonoBehaviour
{
    public bool gameEnded;
    public Text gameHasEnded;
    void Start()
    {
        gameEnded = false;

        gameHasEnded = GameObject.Find("gameHasEnded").GetComponent<Text>();
        gameHasEnded.enabled = false;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (gameEnded)
        {
            gameHasEnded.enabled = true;
            gameHasEnded.text = "The forest has taken you. Retry!";
            Time.timeScale = 0;
        }

    }


}
