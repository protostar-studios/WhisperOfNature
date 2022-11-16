using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnButtons : MonoBehaviour
{

    public Sprite[] resumeSprites;
    public Image resumeButton;
    
    // public Sprite[] quitSprites;
    // public Image quitButton;

    public void Toggle(){
        return;
    }

    public void resumeHover(){
        resumeButton.sprite = resumeSprites[1];
    }

    public void resumeLeaves(){
        resumeButton.sprite = resumeSprites[0];
    }
}
