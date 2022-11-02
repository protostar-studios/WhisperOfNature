using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("AlphaTut");
    }

    public void LoadControls()
    {
        SceneManager.LoadScene("ControlsMenu");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
