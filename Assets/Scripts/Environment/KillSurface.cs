using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSurface : MonoBehaviour
{
    HealthManager death;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player"){
            death = collision.gameObject.GetComponent<HealthManager>();
            death.SetHealth(0);
        }
    }
}
