using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SproutFlowerAnimController : MonoBehaviour
{
    public int growSeason = 0;
    public int dieSeason = 2;
    private SeasonManager seasonManager;
    private Animator flowerAnim;
    void Start()
    {
        seasonManager = FindObjectOfType<SeasonManager>();
        flowerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if(seasonManager.curSeason == growSeason && !flowerAnim.GetBool("Growing")){
            flowerAnim.SetBool("Growing", true);
        }
        if(seasonManager.curSeason != growSeason){
            flowerAnim.SetBool("Growing", false);
        }
        if(seasonManager.curSeason == dieSeason && !flowerAnim.GetBool("Dying")){
            flowerAnim.SetBool("Dying", true);
        }
        if(seasonManager.curSeason != dieSeason){
            flowerAnim.SetBool("Dying", false);
        }
    }
}
