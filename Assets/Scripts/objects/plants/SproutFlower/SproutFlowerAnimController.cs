using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SproutFlowerAnimController : MonoBehaviour
{
    public List<int> growSeason = new List<int>(){0};
    public int dieSeason = 2;
    private SeasonManager seasonManager;
    private Animator flowerAnim;
    private float originalAnimSpeed;
    private bool used = false;
    private bool grown = false;
    private PlantControllerGeneral plantControllerGeneral;
    private bool canGrow = true;
    private bool canDie = false;
    private AudioSource audioSource;
    public AudioClip growSFX = null;
    public AudioClip dieSFX = null;
    void Start()
    {
        seasonManager = FindObjectOfType<SeasonManager>();
        flowerAnim = GetComponent<Animator>();
        plantControllerGeneral = gameObject.GetComponentInParent<PlantControllerGeneral>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(growSeason.Contains(seasonManager.curSeason)){
            grown = true;
        }else{
            grown = false;
        }
        if(growSeason.Contains(seasonManager.curSeason) && !flowerAnim.GetBool("Growing")){
            flowerAnim.SetBool("Growing", true);
            flowerAnim.SetFloat("IdleSpeed", 1.0f);
        }
        if(!growSeason.Contains(seasonManager.curSeason)){
            flowerAnim.SetBool("Growing", false);
        }
        if(!growSeason.Contains(seasonManager.curSeason) && !flowerAnim.GetBool("Dying")){
            flowerAnim.SetBool("Dying", true);
            flowerAnim.SetFloat("IdleSpeed", 10.0f);
            plantControllerGeneral.used = true;
        }
        if(growSeason.Contains(seasonManager.curSeason)){
            flowerAnim.SetBool("Dying", false);
        }
    }
    private void FixedUpdate() {
        if(grown){
            plantControllerGeneral.activateCollider();
            if(canGrow){
                audioSource.PlayOneShot(growSFX);
                canGrow = false;
                canDie = true;
            }
        }else{
            plantControllerGeneral.deactivateCollider();
            if(canDie){
                audioSource.PlayOneShot(dieSFX);
                canDie = false;
                canGrow = true;
            }
        }
    }
    public bool isDead(){
        return flowerAnim.GetCurrentAnimatorStateInfo(0).IsName("FlowerUnderground") && used;
    }
}
