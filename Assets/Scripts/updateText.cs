using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateText : MonoBehaviour
{
    public Text LivesTxt;
    public PlayerManager playerManager;
    private int livesLeft;
    // Start is called before the first frame update
    void Start()
    {
        LivesTxt = GetComponent<Text>();
        livesLeft = playerManager.livesLeft;
        LivesTxt.text = "Lives left: " + livesLeft;

    }

    // Update is called once per frame
    public void UpdateText()
    {
        LivesTxt.text = "Lives left: " + playerManager.livesLeft;

    }
}
