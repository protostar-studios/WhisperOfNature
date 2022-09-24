using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public const int numOfLives = 3;
    public int livesLeft;
    public GameEndedScript gameEndedScript;
    // Start is called before the first frame update
    void Start()
    {
        livesLeft = numOfLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (livesLeft == 0)
        {
            gameEndedScript.gameEnded = true;

        }
    }
}
