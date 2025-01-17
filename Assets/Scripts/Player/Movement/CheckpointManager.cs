using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    GameObject checkpoint;
    Rigidbody rb;
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "checkpoint")
        {
            checkpoint = collider.gameObject;
        }
    }
    public void GoToCheckpoint()
    {
        this.gameObject.transform.parent.transform.position = checkpoint.transform.position;
        this.gameObject.transform.parent.transform.rotation = checkpoint.transform.rotation;
        this.gameObject.transform.position = checkpoint.transform.position;
        this.gameObject.transform.rotation = checkpoint.transform.rotation;
        rb.velocity = new Vector3(0, 0, 0);
    }
}
