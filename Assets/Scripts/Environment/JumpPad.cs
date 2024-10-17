using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] float UpwardsStrength;
    [SerializeField] float ForwardsStrength;

    void OnTriggerEnter(Collider collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.up * UpwardsStrength, ForceMode.Impulse);
            rb.AddForce(transform.forward * ForwardsStrength, ForceMode.Impulse);
        }
    }
}
