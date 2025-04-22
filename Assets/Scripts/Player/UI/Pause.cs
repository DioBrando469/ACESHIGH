using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject playerUI;
    SettingsMenu settings;
    [SerializeField] GameObject PlayerCam;
    CameraMovement cameramov;
    bool paused = false;
    InputSys inputSys;
    KeyCode pause;
    void Start (){
        inputSys = GetComponent<InputSys>();
        cameramov = PlayerCam.GetComponent<CameraMovement>();
        pause = inputSys.pause;
        settings = settingsMenu.GetComponent<SettingsMenu>();
    }
    void PauseGame(){
        paused = true;
        playerUI.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseMenu.SetActive(true);
        inputSys.PausedInputs();
        cameramov.PauseMouseInput(true);
    }
    public void UnPause(){
        paused = false;
        playerUI.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseMenu.SetActive(false);
        inputSys.ReloadInputs();
        cameramov.PauseMouseInput(false);
    }
    void Update () {
        if (Input.GetKeyDown(pause) && paused == false)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(pause) && paused == true && settingsMenu.activeSelf == true)
        {
            settings.ExitMenu();
        }
        else if (Input.GetKeyDown(pause) && paused == true && settingsMenu.activeSelf != true) 
        {
            UnPause();
        }
        
    }
}
