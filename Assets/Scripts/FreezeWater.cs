using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeWater : MonoBehaviour
{
    // Start is called before the first frame update
    private float changeSpeed;
    private SeasonManager seasonManager;
    private Material mat;
    private float opac;
    private Vector3 loweredWater;
    private Vector3 initWater;

    public float waterLevel = 5.0f;
    public float vapouringSpeed = 8.0f;
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        mat = GetComponent<Renderer>().material;
        initWater = transform.position;
        loweredWater = new Vector3(transform.position.x, transform.position.y - waterLevel, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonManager.curSeason == 3){
            GetComponent<Collider>().enabled = true;
            opac = Mathf.SmoothDamp(mat.GetFloat("_iceLevel"), 0.8f, ref changeSpeed, 0.5f, 3.0f);
            mat.SetFloat("_iceLevel", opac);
            mat.SetFloat("_waterSpeed", 1 - opac);
        } else{
            GetComponent<Collider>().enabled = false;
            opac = Mathf.SmoothDamp(mat.GetFloat("_iceLevel"), 0, ref changeSpeed, 0.5f, 3.0f);
            mat.SetFloat("_iceLevel", opac);
            mat.SetFloat("_waterSpeed", 1 - opac);
        }

        if(seasonManager.curSeason == 1){
            // Lower water level
            transform.position = Vector3.MoveTowards(transform.position, loweredWater, vapouringSpeed * Time.deltaTime);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, initWater, vapouringSpeed * Time.deltaTime);
        }

    }
}
