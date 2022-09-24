using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class updateText : MonoBehaviour
{
    public Text LivesTxt;
    public PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        LivesTxt = GetComponent<Text>();
        LivesTxt.text = "Lives left: " + playerManager.livesLeft;

    }

    // Update is called once per frame
    void UpdateText()
    {
        LivesTxt.text = "Lives left: " + playerManager.livesLeft;

    }
}
