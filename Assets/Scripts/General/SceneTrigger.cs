using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] GameObject levelLoader;
    LevelLoader loader;

    void Start()
    {
        loader = levelLoader.GetComponent<LevelLoader>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            loader.LoadNextLevel();
        }
    }
}
