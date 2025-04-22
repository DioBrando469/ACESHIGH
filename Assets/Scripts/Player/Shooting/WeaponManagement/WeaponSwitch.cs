using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    InputSys inputSys;
    KeyCode primarySwitch;
    KeyCode secondarySwitch;
    KeyCode meleeSwitch;
    public GameObject primaryWeapon;
    public GameObject secondaryWeapon;
    public GameObject meleeWeapon;
    GameObject currentWeapon;

    public void SetInputs(){
        inputSys = transform.parent.GetComponent<InputSys>();
        primarySwitch = inputSys.weapon1;
        secondarySwitch = inputSys.weapon2;
        meleeSwitch = inputSys.weapon3;
    }
    void Start()
    {
        SetInputs();
        currentWeapon = primaryWeapon;
        primaryWeapon.SetActive(true);
        secondaryWeapon.SetActive(false);
    }
    void Update()
    {
        
        if(Input.GetKeyDown(primarySwitch) && currentWeapon != primaryWeapon)
        {
            SwitchWeapons(primaryWeapon);
            currentWeapon = primaryWeapon;
        }
        if(Input.GetKeyDown(secondarySwitch) && currentWeapon != secondaryWeapon)
        {
            SwitchWeapons(secondaryWeapon);
            currentWeapon = secondaryWeapon;
        }
        if(Input.GetKeyDown(meleeSwitch) && currentWeapon != meleeWeapon)
        {
            SwitchWeapons(meleeWeapon);
            currentWeapon = meleeWeapon;
        }
    }
    void SwitchWeapons(GameObject weapon)
    {
        primaryWeapon.SetActive(false);
        secondaryWeapon.SetActive(false);
        meleeWeapon.SetActive(false);
        weapon.SetActive(true);
    }
    public GameObject ReturnCurWeapon()
    {
        return currentWeapon;
    }
}
