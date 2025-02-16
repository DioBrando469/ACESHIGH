using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] GameObject deathscreen;
    public void Activate(bool a)
    {
        deathscreen.SetActive(a);
    }
}
