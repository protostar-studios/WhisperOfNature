using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcebergSeason : MonoBehaviour
{
    private SeasonManager seasonManager;
    private Vector3 initPos;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (seasonManager.curSeason)
        {
            case 1:
                Vector3 newPos = initPos + Vector3.up * 0.5f;
                transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
                break;
            default:
                transform.position = Vector3.MoveTowards(transform.position, initPos, speed * Time.deltaTime);
                break;
        }
    }
}
