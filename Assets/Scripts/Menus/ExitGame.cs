using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExitGame : MonoBehaviour
{
    [SerializeField] Button button;
    public void CloseGame()
    {
        print("closing");
        Application.Quit();
    }
    void OnButtonClick(){
        CloseGame();
    }
    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }
    
    
}
