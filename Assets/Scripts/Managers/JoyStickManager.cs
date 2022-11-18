using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickManager : MonoBehaviour
{
    public string joyStick = "PS_";
    void Awake()
    {
        foreach (var item in Input.GetJoystickNames())
        {
            if(item.Contains("X")){
                joyStick = "Xbox_";
            }
        }
    }
}
