using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{

    public void SelectLevel1()
    {
        SceneManager.LoadScene("AlphaTut");
    }

    public void SelectLevel2()
    {
        SceneManager.LoadScene("Level 1 - Beta");
    }

    public void SelectLevel3()
    {
        SceneManager.LoadScene("Level 2");
    }

}
