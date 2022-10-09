using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeasonText : MonoBehaviour
{

    private SeasonManager seasonManager;

    public GameObject currSeasonObj;
    public Text currSeason;
    

    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        currSeason = currSeasonObj.GetComponent<Text>();
        currSeason.text = "Summer";
    }

    // Update is called once per frame
    void Update()
    {
        switch (seasonManager.curSeason)
        {
            case 0:
                currSeason.text = "Spring";
                break;
            case 1:
                currSeason.text = "Summer";
                break;
            case 2:
                currSeason.text = "Fall";
                break;
            case 3:
                currSeason.text = "Winter";
                break;
            default:
                currSeason.text = "Summer";
                break; 
        }
    }
}
