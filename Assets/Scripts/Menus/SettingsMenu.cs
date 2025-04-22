using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public UnityEvent ConfigChanged;
    [SerializeField] GameObject mainMenu;
    string TheValue;
    playerconfig config;
    ConfigManager manager;
    string value;
    //float newresolutionx;
    void Start()
    {
        //print(Convert.ToString(KeyCode.Mouse0));
        manager = new ConfigManager();
        manager.LoadConfig();
        config = new playerconfig();
        config = manager.ReturnConfig();
    }
    public void GetValue()
    {
        TheValue = EventSystem.current.currentSelectedGameObject.name;
    }
    public void SetValue(string value)
    {
        try{
            config.ChangeParam(TheValue, value);
        }
        catch(Exception ex)
        {
            print("ошибка");
        }
    }
    public void SetSliderValue()
    {
        try{
            config.ChangeParam(TheValue, Convert.ToString(GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponent<Slider>().value));
        }
        catch(Exception ex)
        {
            print("ошибка");
        }
    }
    public void SetKeyValue(string value)
    {
        try{
            KeyCode keycode = (KeyCode) System.Enum.Parse(typeof(KeyCode), value, true);
            config.ChangeParam(TheValue, keycode);
        }
        catch(Exception ex)
        {
            print("ты чё дурак?");
        }
    }
    public void PrintValue()
    {
        print(TheValue);
    }
    public void SaveChanges()
    {
        manager.SetNewStruct(config);
        manager.SaveConfig();
        ConfigChanged.Invoke();
    }
    public void ExitMenu()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
