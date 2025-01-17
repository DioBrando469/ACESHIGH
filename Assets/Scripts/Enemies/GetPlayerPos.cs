using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetPlayerPos : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] Transform defaultPos;
    Vector3 dirtoplayer;
    bool foundplayer;
    RaycastHit hit;
    void Start()
    {
        defaultPos = transform.parent.parent.transform;
        dirtoplayer = GetDir(transform.position, defaultPos.position);
        foundplayer = false;
    }
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && collider.gameObject.GetComponent<HealthManager>() != null)
        {
            if (Physics.Raycast(transform.position, GetDir(transform.position, collider.gameObject.transform.position), out hit, range))
            {
                if(hit.collider.gameObject.tag == "Player")
                {
                    foundplayer = true;
                    dirtoplayer = GetDir(transform.position, hit.point);
                }
                //else
                //{
                //    foundplayer = false;
                //    dirtoplayer = GetDir(transform.position, defaultPos.position);
                //}
            }
        }
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "startingPos" && foundplayer == false)
        {
            dirtoplayer = dirtoplayer * 0f;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        foundplayer = false;
        dirtoplayer = GetDir(transform.position, defaultPos.position);
    }

    public Vector3 ReturnDir()
    {
        return dirtoplayer;
    }
    public bool ReturnFoundPlayer()
    {
        return foundplayer;
    }
    Vector3 GetDir(Vector3 origin, Vector3 hit)
    {
        Vector3 direction = hit - origin;
        return direction;
    }
}
