using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class Rocket : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] LayerMask playerMask;
    [SerializeField] float coef;
    [SerializeField] float power;
    [SerializeField] float radius;
    [SerializeField] float verticalPower;
    [SerializeField] float damage;
    [SerializeField] float falloff;
    [SerializeField] float minDamage;
    //TeamAssign team;
    EnemyHealth health;
    void Awake()
    {
        //if(this.transform.parent != null && this.transform.parent.tag == "Player")
        //{
        //    playerMask = LayerMask.NameToLayer("Player");
        //}
        //else if(this.transform.parent != null && (this.transform.parent.tag == "Enemy" || this.transform.parent.tag == "EnemyRadius"))
        //{
        //    playerMask = LayerMask.NameToLayer("Enemy");
        //}
    }
    void OnTriggerEnter(Collider collision)
    {
        if(playerMask != (playerMask | 1 << collision.gameObject.layer))
        {
            print(collision.gameObject.layer);
            Explode();
            Destroy(gameObject);
        }
    }
    void Explode()
    {
        Instantiate (explosion, transform.position, Quaternion.identity);
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            //TeamAssign team = hit.GetComponent<TeamAssign>();
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, verticalPower);
            health = hit.gameObject.GetComponent<EnemyHealth>();
            //if(hit.gameObject == this.transform.parent.gameObject)
            //{
            //    if(health != null)
            //    health.TakeDamage(0);
            //}
            if(health != null)
            {
                //if (hit.gameObject != this.transform.parent.gameObject)
                //{
                    if (health != null)
                    {
                        health.TakeDamage(System.Convert.ToInt32(Mathf.Clamp(System.Convert.ToSingle((damage - (Vector3.Distance(transform.position, hit.transform.position)) * coef)) - (Vector3.Distance(hit.transform.position, this.transform.parent.position) * falloff), minDamage, damage)));
                    }
                //}
            }
            
        }
    }
}
