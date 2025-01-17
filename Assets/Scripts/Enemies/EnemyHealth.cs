using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxhealth;
    EnemyRespawn res;
    GameObject respawnpos;
    public int currenthealth;
    
    void Start()
    {
        respawnpos = transform.parent.gameObject;
        if(respawnpos != null)
        res = respawnpos.GetComponent<EnemyRespawn>();
        currenthealth = maxhealth;
    }

    void Update()
    {
        if(currenthealth <= 0)
        {
            if(res != null)
            res.InvokeRespawn();
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
    }
}
