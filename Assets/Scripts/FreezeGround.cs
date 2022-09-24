using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGround : MonoBehaviour
{

    public Material Summer_Floor_tile;
    public Material Winter_Floor_tile;

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
            if (frozen){
                GetComponent<Renderer>().material = Winter_Floor_tile;
            }
            else{
                GetComponent<Renderer>().material = Summer_Floor_tile;
            }
        }
    }
}
