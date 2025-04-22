using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
//using Mono.Cecil.Cil;
using UnityEngine;

public class playerconfig
{
    public float resolutionx  = 1920;
    public float resolutiony  = 1080; 
    public bool fullscreen = true; 
    public float volume  = 1; 
    public float sensitivity = 12; 
    public KeyCode pause  = KeyCode.Escape; 
    public KeyCode jump  = KeyCode.Space;
    public KeyCode shoot  = KeyCode.Mouse0; 
    public KeyCode weapon1  = KeyCode.Alpha1; 
    public KeyCode weapon2  = KeyCode.Alpha2; 
    public KeyCode weapon3  = KeyCode.Alpha3; 
    public KeyCode reload = KeyCode.R; 
    public void ChangeParam(string name, string value)
    {
        if (name == "resolutionx"){
            resolutionx = Convert.ToInt32(value);
        }
        if (name == "resolutiony"){
            resolutiony = Convert.ToInt32(value);
        }
        if (name == "volume"){
            volume = Convert.ToSingle(value);
        }
        if (name == "sens"){
            sensitivity = Convert.ToSingle(value);
        }
    }
    public void ChangeParam(string name, bool value)
    {
        if (name == "fullscreen"){
            fullscreen = value;
        }
    }
    public void ChangeParam(string name, KeyCode value)
    {
        if (name == "pause"){
            pause = value;
        }
        if (name == "jump"){
            jump = value;
        }
        if (name == "shoot"){
            shoot = value;
        }
        if (name == "reload"){
            reload = value;
        }
        if (name == "weapon1"){
            weapon1 = value;
        }
        if (name == "weapon2"){
            weapon2 = value;
        }
        if (name == "weapon3"){
            weapon3 = value;
        }
    }

}
