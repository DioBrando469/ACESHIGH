using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public static playerconfig Config {get; set;}
    public void SetNewStruct(playerconfig config)
    {
        Config = config;
    }
    public void SaveConfig()
    {
        string json = JsonUtility.ToJson(Config);
        File.WriteAllText(Application.dataPath + @"config.json", json);
    }
    public void LoadConfig()
    {
        string savedjson = File.ReadAllText(Application.dataPath + @"config.json");
        Config = JsonUtility.FromJson<playerconfig>(savedjson);
    }
    void Awake()
    {
        LoadConfig();
    }
    public playerconfig ReturnConfig()
    {
        return Config;
    }
}
