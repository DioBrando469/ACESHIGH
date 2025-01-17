using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Transform startingpos;
    [SerializeField] float interval;
    //[SerializeField] float quantity;
    //[SerializeField] GameObject[] enemies;

    //void Update()
    //{
    //    
    //}
    public void InvokeRespawn()
    {
        Invoke("Respawn", interval);
    }
    void Respawn()
    {
        Instantiate(enemy, startingpos.position, Quaternion.identity, gameObject.transform);
    }
}
