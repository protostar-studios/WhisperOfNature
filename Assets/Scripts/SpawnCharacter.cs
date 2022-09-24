using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{

    private GameObject _playerChar;
    private Transform _playerTransform;
    private Rigidbody _rigidbody;


    private Vector3 _charSpawnLocation = GameObject.FindGameObjectWithTag("Cauldron").transform.position - Vector3.forward * 3;

    private const float RESPAWN_HEIGHT = -50f;

    public int PlayerLivesLeft;
    public const int NumOfLives = 1;
    public bool GameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        // spawns the prefab named Character from the Resources folder
        _playerChar = GameObject.Instantiate(Resources.Load("Player"),
            _charSpawnLocation, Quaternion.identity) as GameObject;

        //_playerChar.transform.position = _charSpawnLocation;

        _playerTransform = _playerChar.transform;
        _rigidbody = _playerChar.GetComponent<Rigidbody>();

        PlayerLivesLeft = NumOfLives; //start off with full lives
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerTransform.position.y <= RESPAWN_HEIGHT)
        {
            if (PlayerLivesLeft > 0)
            {
                //Respawn
                _playerTransform.position = _charSpawnLocation; // reset the player back to the start
                _rigidbody.velocity = new Vector3(0, 0, 0);

                PlayerLivesLeft -= 1;
            } else
            {
                EndGame();
                //pause the game
            }
            
        }
    }

    private void EndGame()
    {
        GameEnded = true;
        Time.timeScale = 0;
        Debug.Log("Game Ended!");
    }
}
