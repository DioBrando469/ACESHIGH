using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetButtonInput : MonoBehaviour
{
    SettingsMenu menu;
    Button button;
    TextMeshPro text;
    KeyCode input;
    void Start()
    {
        menu = gameObject.transform.parent.gameObject.GetComponent<SettingsMenu>();
        text = GetComponent<TextMeshPro>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    void OnClick(){
        if (Input.anyKey){
        }
    }
}
