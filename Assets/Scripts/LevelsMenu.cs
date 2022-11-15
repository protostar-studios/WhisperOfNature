using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{

    public void SelectLevel1()
    {
        SceneManager.LoadScene("The Call of the Forest");
    }

    public void SelectLevel2()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SelectLevel3()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
