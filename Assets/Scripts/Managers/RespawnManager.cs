using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{   
    public Transform curRespawn;
    public List<Transform> respawnPoints = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        // The first respawn point on list is by default the starting pos
        setRespawn(0);
    }

    public void setRespawn(int i){
        curRespawn = respawnPoints[i];
    }
}
