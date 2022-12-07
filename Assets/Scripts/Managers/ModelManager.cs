using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public GameObject autumnPrefab;
    public GameObject springPrefab;
    public GameObject summerPrefab;
    public GameObject winterPrefab;

    
    public CamControl playerCam;
    public GameObject currentModel;


    private SeasonManager seasonManager;
    private int curSeason;
    private GameObject newModel;
    private GameObject oldModel;

    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        ChangeSeasonModel();
        curSeason = seasonManager.curSeason;
        // playerCam = GameObject.FindObjectOfType<Camera>();

    }

    GameObject ChangeModel(int season){

        Vector3 pos = currentModel.transform.position;
        Quaternion rot = currentModel.transform.rotation;    
        if(season == 0){
            newModel = Instantiate(springPrefab, pos, rot, this.transform) as GameObject;
        }
        else if(season == 1){
            newModel = Instantiate(summerPrefab, pos, rot, this.transform) as GameObject;
        }
        else if(season == 2){
            newModel = Instantiate(autumnPrefab, pos, rot, this.transform) as GameObject;
        }
        else if(season == 3){
            newModel = Instantiate(winterPrefab, pos, rot, this.transform) as GameObject;
        }
        return newModel;
    }

    public Animator GetAnimator(){
        return currentModel.GetComponent<Animator>();
    }
    // Update is called once per frame
    public void ChangeSeasonModel()
    {  
        if (curSeason != seasonManager.curSeason){
            newModel = ChangeModel(seasonManager.curSeason);
            oldModel = currentModel;
            Destroy(oldModel);
            currentModel = newModel;
            curSeason = seasonManager.curSeason;
        }
    }
}
