using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class InputSys : MonoBehaviour
{
    public UnityEvent InputChange;
    [SerializeField] ConfigManager configManager;
    playerconfig config;
    public float sens { get; private set; }
    public KeyCode pause {get; private set;}
    public KeyCode jump {get; private set;}
    public KeyCode shoot {get; private set;}
    public KeyCode weapon1 {get; private set;}
    public KeyCode weapon2 {get; private set;}
    public KeyCode weapon3 {get; private set;}
    public KeyCode reload {get; private set;}
    public void ReloadInputs()
    {
        config = configManager.ReturnConfig();
        sens = config.sensitivity;
        pause = config.pause;
        jump = config.jump;
        shoot = config.shoot;
        weapon1 = config.weapon1;
        weapon2 = config.weapon2;
        weapon3 = config.weapon3;
        reload = config.reload;
        InputChange.Invoke();
    }
    public void PausedInputs(){
        jump = KeyCode.None;
        shoot = KeyCode.None;
        weapon1 = KeyCode.None;
        weapon2 = KeyCode.None;
        weapon3 = KeyCode.None;
        reload = KeyCode.None;
        InputChange.Invoke();
    }
    void Awake()
    {
        ReloadInputs();
    }
}
