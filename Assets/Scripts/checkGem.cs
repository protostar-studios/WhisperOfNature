using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGem : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerManager player;
    void Start()
    {
        player = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
