using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeasonText : MonoBehaviour
{

    private SeasonManager seasonManager;

    public GameObject currSeasonObj;
    public GameObject currSeasonObj2; // radial wheel
    public Text currSeason;

    public Sprite springImage;
    public Sprite fallImage;
    public Sprite winterImage;
    public Sprite summerImage;
    
    private Image currImg;

    // Start is called before the first frame update
    void Start()
    {
        seasonManager = Object.FindObjectOfType<SeasonManager>();
        currSeason = currSeasonObj.GetComponent<Text>();
        currSeason.text = "Summer";
        currImg = currSeasonObj2.GetComponent<Image>();
        currImg.sprite = springImage;
    }

    // Update is called once per frame
    void Update()
    {
        switch (seasonManager.curSeason)
        {
            case 0:
                currImg.sprite = springImage;
                currSeason.text = "Spring";
                break;
            case 1:
                currImg.sprite = summerImage;
                currSeason.text = "Summer";
                break;
            case 2:
                currImg.sprite = fallImage;
                currSeason.text = "Fall";
                break;
            case 3:
                currImg.sprite = winterImage;
                currSeason.text = "Winter";
                break;
            default:
                currImg.sprite = summerImage;
                currSeason.text = "Summer";
                break; 
        }
    }
}
