using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlant : MonoBehaviour
{

    public Material plantSpring;
    public Material plantWinter;

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
            if (frozen)
            {
                GetComponent<Renderer>().material = plantWinter;
            }
            else
            {
                GetComponent<Renderer>().material = plantSpring;
            }
        }
    }
}
