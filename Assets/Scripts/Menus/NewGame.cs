using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class NewGame : MonoBehaviour
{
    [SerializeField] Button button;
    void Start (){
        button.onClick.AddListener(OnButtonClick);
    }
    void OnButtonClick()
    {
        SceneManager.LoadScene("Level1");
    }
}
