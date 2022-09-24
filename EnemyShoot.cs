using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;
    public AudioSource shootingSound;

    float timer = 0;
    int waitingTime = 3;
    bool frozen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            frozen = !frozen;
        }

        if (!frozen){
            timer += Time.deltaTime;
        }

        if (timer > waitingTime && !frozen){
            // Action
            Instantiate(projectile, transform.position + (transform.forward), transform.rotation);
            shootingSound.Play();
            // reset timer
            timer = 0;
        }
    }

    void FreezeEnemy()
    {
        frozen = !frozen;
        timer = 0;
    }
}
