using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    [SerializeField] GameObject shooter;
    [SerializeField] GameObject projectileOrigin;
    [SerializeField] float firingSpeed;
    [SerializeField] float radius;
    [SerializeField] float inaccuracy;
    float shottimer;
    ProjectileShooter fire;
    RaycastHit hit;
    bool canshoot = true;
    void Start (){
        fire = shooter.GetComponent<ProjectileShooter>();
        shottimer = 0;
    }
    void Update()
    {
        shottimer += Time.deltaTime;
    }
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && collider.gameObject.GetComponent<HealthManager>() && shottimer >= firingSpeed)
        {
            shottimer = 0;
            InvokeFire(GetDir(projectileOrigin.transform.position, collider.transform.position));
            
        }
    }
    void InvokeFire(Vector3 direction)
    {
        if (Physics.Raycast(projectileOrigin.transform.position, direction, out hit, radius))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                fire.Shoot(GetDir(projectileOrigin.transform.position, hit.point));
            }
        }
        canshoot = true;
    }
    Vector3 GetDir(Vector3 origin, Vector3 hit)
    {
        Vector3 direction = hit - origin;
        Vector3 directionWithSpread = new Vector3
        (
            direction.x + Random.Range(-inaccuracy, inaccuracy),
            direction.y + Random.Range(-inaccuracy, inaccuracy),
            direction.z + Random.Range(-inaccuracy, inaccuracy)
        );
        return directionWithSpread;
    }
}
