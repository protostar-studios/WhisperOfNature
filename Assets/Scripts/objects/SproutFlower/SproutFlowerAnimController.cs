using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SproutFlowerAnimController : MonoBehaviour
{
    public List<int> growSeason = new List<int>(){0, 1};
    public int dieSeason = 2;
    private SeasonManager seasonManager;
    private Animator flowerAnim;
    private float originalAnimSpeed;
    void Start()
    {
        seasonManager = FindObjectOfType<SeasonManager>();
        flowerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if(growSeason.Contains(seasonManager.curSeason) && !flowerAnim.GetBool("Growing")){
            flowerAnim.SetBool("Growing", true);
            flowerAnim.SetFloat("idleSpeed", 1.0f);
        }
        if(!growSeason.Contains(seasonManager.curSeason)){
            flowerAnim.SetBool("Growing", false);
        }
        if(!growSeason.Contains(seasonManager.curSeason) && !flowerAnim.GetBool("Dying")){
            flowerAnim.SetBool("Dying", true);
            flowerAnim.SetFloat("idleSpeed", 10.0f);
        }
        if(growSeason.Contains(seasonManager.curSeason)){
            flowerAnim.SetBool("Dying", false);
        }
    }
}
