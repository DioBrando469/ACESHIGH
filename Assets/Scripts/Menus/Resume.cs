using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{

    [SerializeField] Button resumebutton;
    [SerializeField] GameObject player;
    Pause pause;
    void Start(){
        pause = player.GetComponent<Pause>();
        resumebutton.onClick.AddListener(OnClick);
    }
    void OnClick(){
        pause.UnPause();
    }
}
