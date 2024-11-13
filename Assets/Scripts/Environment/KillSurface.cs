using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSurface : MonoBehaviour
{
    [SerializeField] Transform checkpoint;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"){
            collision.transform.position = checkpoint.position;
            collision.transform.rotation = checkpoint.rotation;
            collision.rigidbody.velocity = new Vector3(0, 0, 0);
        }
    }
}
