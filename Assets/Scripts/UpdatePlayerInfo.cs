using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerInfo : MonoBehaviour
{
    public GameObject playerTimerObj;
    private float timerLeft = 120;
    private Text timerText;
    public GameObject playerInventoryObj;
    private Text mushroomText;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        timerText = playerTimerObj.GetComponent<Text>();
        initializeTimer();
        mushroomText = playerInventoryObj.GetComponent<Text>();

    }

    public void initializeTimer(){
        timerLeft = 120;
        updateTimerText();
    }

    public void updateTimerText(){
        timerText.text = "Time Left: " + (int)timerLeft + "s";
    }

    public void updateMushroomText(){
            if(scoreManager.getScore() > 0 ){
                mushroomText.text = "Mushroom x" + scoreManager.getScore();
            } else{
                mushroomText.text = "Empty";
            }

    }

    // Update is called once per frame
    void Update()
    {
        if(timerLeft > 0){
            timerLeft = timerLeft - Time.deltaTime;
            updateTimerText();
        }
    }
}
