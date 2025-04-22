using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetPlayerPos : MonoBehaviour
{
    Coroutine lookCoroutine;
    [SerializeField] float range;
    [SerializeField] Transform defaultPos;
    [SerializeField] float looktime;
    Transform target;
    Vector3 dirtoplayer;
    bool foundplayer;
    RaycastHit hit;
    void Start()
    {
        
        defaultPos = transform.parent.parent.transform;
        target = defaultPos;
        foundplayer = false;
        lookCoroutine = StartCoroutine(LookForPlayerCoroutine(looktime));
    }
    void Update()
    {
        //dirtoplayer = GetDir(transform.position, target.position);
    }
    IEnumerator LookForPlayerCoroutine(float looktime)
    {
        while (true)
        {
            dirtoplayer = GetDir(transform.position, target.position);
            yield return new WaitForSeconds(looktime);
        }
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
                    target = collider.gameObject.transform;
                }
                //else
                //{
                //    foundplayer = false;
                //    dirtoplayer = GetDir(transform.position, defaultPos.position);
                //}
            }
            else
            {
                foundplayer = false;
                
            }
        }
        
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == this.transform.parent.parent.gameObject && foundplayer == false)
        {
            dirtoplayer = dirtoplayer * 0f;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && collider.gameObject.GetComponent<HealthManager>() != null)
        {
            foundplayer = false;
            target = defaultPos;
        }
        
        
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
