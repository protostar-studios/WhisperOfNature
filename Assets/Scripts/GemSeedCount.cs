using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemSeedCount : MonoBehaviour
{

    public Sprite[] numberCountSprites;
    public Image gemImage;
    public Image seedImage;
    public PlayerManager playerManager;

    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int gemCount = playerManager.inventory["Gem"];
        int seedCount = playerManager.inventory["Seed"];
        gemImage.sprite = numberCountSprites[gemCount];
        seedImage.sprite = numberCountSprites[seedCount];
    }
}
