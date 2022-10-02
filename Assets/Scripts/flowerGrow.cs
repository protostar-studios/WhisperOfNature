using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerGrow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 initPos;
    private Vector3 initScale;
    private SeasonManager seasonManager;
    public float growRate = 2f;
    private Transform flower;
    private Transform stem;
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        flower = transform.GetChild(0);
        initPos = flower.position;
        stem = transform.GetChild(1);
        initScale = stem.localScale;
        //flower.transform.localScale += new Vector3(1f, 1f, 1f) * growRate;
    }

    // Update is called once per frame
    void Update()
    {
        switch (seasonManager.curSeason)
        {
            case 0:
                Vector3 newScale = new Vector3(initScale.x, initScale.y * 3, initScale.z);
                stem.localScale = Vector3.MoveTowards(stem.localScale, newScale, growRate * Time.deltaTime);
                Vector3 newPos = new Vector3(flower.position.x, (initPos.y - transform.position.y) * 3 + transform.position.y, flower.position.z);
                flower.position = Vector3.MoveTowards(flower.position, newPos, (growRate - 1f) * Time.deltaTime);
                break;
            default:
                flower.position = Vector3.MoveTowards(flower.position, initPos, (growRate - 1f) * Time.deltaTime);
                stem.localScale = Vector3.MoveTowards(stem.localScale, initScale, (growRate + 0.5f) * Time.deltaTime);
                break;
        }
        
    }
}
