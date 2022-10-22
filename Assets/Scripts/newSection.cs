using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSection : MonoBehaviour
{
    public GameObject player;
    public GameObject currGate;
    private PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerManager.inventory["Gem"] > 0) {
                // Destroy(transform.root.gameObject);
                Destroy(currGate);
                playerManager.inventory["Gem"] = playerManager.inventory["Gem"] - 1; 
            }
        }
    }
}
