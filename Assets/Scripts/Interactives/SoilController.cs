using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilController : MonoBehaviour
{
    // The growable on the soil
    public GameObject plantObject = null;
    private GameObject plantedPlant = null;
    private bool isPlanted = false;
    // private PlantControllerGeneral plantControl = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Delete the plant object when the growing period is over.
        // Decided not to use this feature

        // if(plantControl != null && plantControl.isDead()){
        //     Destroy(plantedPlant);
        //     plantedPlant = null;
        //     plantControl = null;
        //     isPlanted = false;
        // }
    }

    public bool Plant(){
        if(isPlanted || plantObject == null){
            return false;
        }
        Vector3 newpos = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
        plantedPlant = Instantiate(plantObject, newpos, transform.rotation) as GameObject;
        plantedPlant.transform.localScale = transform.localScale;
        // plantControl = plantedPlant.GetComponentInParent<PlantControllerGeneral>();
        isPlanted = true;
        Destroy(GetComponentInChildren<SoilSeedRotation>().gameObject);
        return true;
    }
}
