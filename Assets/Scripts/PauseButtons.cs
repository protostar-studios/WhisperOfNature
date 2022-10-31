using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtons : MonoBehaviour
{

    public Sprite[] resumeSprites;
    public Image resumeButton;
    // public Sprite[] quitSprites;
    // public Image quitButton;

    public void Toggle(){
        // if (resumeButton.sprite == resumeSprites[0]){
        //     resumeButton.sprite = resumeSprites[1];
        //     return;
        // }
        // resumeButton.sprite = resumeSprites[0];
    }

    public void resumeHover(){
        resumeButton.sprite = resumeSprites[1];
    }

    public void resumeLeaves(){
        resumeButton.sprite = resumeSprites[0];
    }

    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (PauseMenu.paused == true){
    //         Debug.Log("ahah");
    //         resumeButton.image.sprite = defaultImg;
    //     }
    // }
}
