using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSection : MonoBehaviour
{
    public GameObject player;
    public GameObject currGate;
    public int respawnPosIndex = 0;
    private PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = player.GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerManager.inventory["Gem"] > 0) {
                // Destroy(transform.root.gameObject);
                Destroy(currGate);
                // Destroy Rotating Gem Indicator
                transform.Find("GemIndicator").gameObject.SetActive(false);
                playerManager.inventory["Gem"] = playerManager.inventory["Gem"] - 1; 
                // Instantiate Actual Gem 
                transform.Find("ActualGem").gameObject.SetActive(true);
                FindObjectOfType<RespawnManager>().setRespawn(respawnPosIndex);
            }
        }
    }
}
