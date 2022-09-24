using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 10;
    public float bound = 100;
    public PlayerManager playerManager;
    public updateText updateTextLives;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x) > bound || Mathf.Abs(transform.position.z) > bound)
        {
            Destroy(gameObject);
            playerManager.livesLeft--;
            updateTextLives.UpdateText();
        }
    }
}
