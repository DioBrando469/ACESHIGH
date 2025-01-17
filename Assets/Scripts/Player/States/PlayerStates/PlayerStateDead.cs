using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateDead : PlayerStateBase
{
    GameObject Object;
    CheckpointManager cm;
    HealthManager hp;
    public override void EnterState(PlayerStateManager player)
    {
        Object = player.gameObject;
        cm = Object.GetComponent<CheckpointManager>();
        hp = Object.GetComponent<HealthManager>();
        print("you're dead lol");
    }
    public override void UpdateState(PlayerStateManager player)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            cm.GoToCheckpoint();
            hp.SetHealth(hp.ReturnMaxHealth());
            player.SwitchState(player.AliveState);
        }
    }
}
