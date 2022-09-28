using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerGrow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject flower;
    public float growRate = 2f;
    void Start()
    {
        //flower.transform.localScale += new Vector3(1f, 1f, 1f) * growRate;
    }

    // Update is called once per frame
    void Update()
    {
       flower.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * growRate *Time.deltaTime;
        
    }
}
