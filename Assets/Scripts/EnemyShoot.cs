using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;

    float timer = 0;
    int waitingTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime){
            // Action
            Instantiate(projectile, transform.position + (transform.forward), transform.rotation);

            // reset timer
            timer = 0;
        }
    }
}
