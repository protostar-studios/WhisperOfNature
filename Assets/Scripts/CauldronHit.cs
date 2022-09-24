using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronHit : MonoBehaviour
{

    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (GameEnd()){
                Debug.Log("Game End"); // destroy this coin
                Time.timeScale = 0;
            }
        }
    }

    private bool GameEnd() {
        if (scoreManager.getScore() == 3) 
        {
            return true;
        }
        return false;
    }
}
