using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform projectileOrigin;
    [SerializeField] Transform Owner;
    [Header("Stats")]
    [SerializeField] float firerate;
    //[SerializeField] float projectileSpeed;
    [SerializeField] float shootForce, upwardForce;
    [SerializeField] float inaccuracy;
    bool isShooting;
    public bool allowInvoke = true;
    

    public void Shoot(Vector3 direction)
    {   
        if(isShooting == false)
        {
            isShooting = true;
            GameObject currentprojectile = Instantiate(projectile, projectileOrigin.position, Quaternion.identity, Owner);
            currentprojectile.transform.forward = direction.normalized;
            currentprojectile.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
            currentprojectile.GetComponent<Rigidbody>().AddForce(projectileOrigin.transform.up * upwardForce, ForceMode.Impulse);
            if(allowInvoke)
            {
                Invoke("ResetShot", firerate);
                allowInvoke = false;
            }
        }
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
    void ResetShot()
    {
        allowInvoke = true;
        //readyToShoot = true;
        isShooting = false;
    }
}
