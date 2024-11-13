using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    [SerializeField] int weaponSlot;
    WeaponSwitch weaponSwitch;
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<WeaponSwitch>() != null)
        {
            weaponSwitch = collision.gameObject.GetComponent<WeaponSwitch>();
            if(weaponSlot == 1)
            {
                weaponSwitch.primaryWeapon = weapon;
            }
            else if(weaponSlot == 2)
            {
                weaponSwitch.secondaryWeapon = weapon;
            }
            else
            {
                weaponSwitch.meleeWeapon = weapon;
            }
            Destroy(gameObject);
        }
    }
}
