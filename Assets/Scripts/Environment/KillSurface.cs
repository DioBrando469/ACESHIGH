using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSurface : MonoBehaviour
{
    CheckpointManager checkpoint;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player"){
            checkpoint = collision.gameObject.GetComponent<CheckpointManager>();
            checkpoint.GoToCheckpoint();
        }
    }
}
