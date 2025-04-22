using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateDead : PlayerStateBase
{

    KeyCode respawn;
    InputSys inputSys;
    GameObject Object;
    CheckpointManager cm;
    HealthManager hp;
    PlayerMovement pm;
    WeaponSwitch ws;
    DeathScreen deathScreen;
    public void ResetInput(GameObject obj)
    {
        inputSys = obj.transform.parent.gameObject.GetComponent<InputSys>();
        respawn = inputSys.jump;
    }
    public override void EnterState(PlayerStateManager player)
    {
        Object = player.gameObject;
        cm = Object.GetComponent<CheckpointManager>();
        hp = Object.GetComponent<HealthManager>();
        pm = Object.GetComponent<PlayerMovement>();
        ws = Object.GetComponent<WeaponSwitch>();
        deathScreen = Object.GetComponent<DeathScreen>();
        deathScreen.Activate(true);
        pm.enabled = false;
        ws.ReturnCurWeapon().SetActive(false);
        print("you're dead lol");
        ResetInput(Object);
    }
    public override void UpdateState(PlayerStateManager player)
    {
        if(Input.GetKeyDown(respawn))
        {
            deathScreen.Activate(false);
            pm.enabled = true;
            ws.ReturnCurWeapon().SetActive(true);
            cm.GoToCheckpoint();
            hp.SetHealth(hp.ReturnMaxHealth());
            player.SwitchState(player.AliveState);
        }
    }
}
