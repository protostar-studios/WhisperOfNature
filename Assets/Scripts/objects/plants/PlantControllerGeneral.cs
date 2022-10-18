using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantControllerGeneral : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator plantAnim;
    public bool used = false;
    public string deadState = "";
    void Start()
    {
        plantAnim = GetComponentInChildren<Animator>();
    }

    public bool isDead(){
        return plantAnim.GetCurrentAnimatorStateInfo(0).IsName(deadState) && used;
    }
}
