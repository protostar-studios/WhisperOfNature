using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;

    public AudioSource shootingSound;

    float timer = 0;
    int waitingTime = 1;
    bool frozen = false;
    //public GameObject enemy;
    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        
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
            anim.Play("plant");
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
