using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Rendering;
using UnityEngine;

public class DefaultConfigSettings : MonoBehaviour
{
    public static playerconfig config = new playerconfig();
    public playerconfig defaultconfig = new playerconfig();
    ConfigManager manager;
    void Awake()
    {
        defaultconfig.resolutionx = 1920;
        defaultconfig.resolutiony = 1080;
        defaultconfig.fullscreen = true;
        defaultconfig.pause = KeyCode.Escape;
        defaultconfig.volume = 1;
        defaultconfig.sensitivity = 12;
        defaultconfig.jump = KeyCode.Space;
        defaultconfig.shoot = KeyCode.Mouse0;
        defaultconfig.reload = KeyCode.R;
        defaultconfig.weapon1 = KeyCode.Alpha1;
        defaultconfig.weapon2 = KeyCode.Alpha2;
        defaultconfig.weapon3 = KeyCode.Alpha3;
        manager = GetComponent<ConfigManager>();
        if (File.Exists(Application.dataPath + @"config.json") == false || 
        File.ReadAllText(Application.dataPath + @"config.json") == "" ||
        File.ReadAllText(Application.dataPath + @"config.json") == null)
        {
            config = defaultconfig;
            manager.SetNewStruct(config);
            manager.SaveConfig();
            manager.LoadConfig();
        }
    }
    public playerconfig ReturnConfig()
    {
        return defaultconfig;
    }
}
