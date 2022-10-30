using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickManager : MonoBehaviour
{
    public string joyStick = "PS_";
    void Start()
    {
        foreach (var item in Input.GetJoystickNames())
        {
            if(item.Contains("Xbox")){
                joyStick = "Xbox_";
            }
        }
    }
}
