using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(Player player)
    {

        if (player.characterList.Count > 0)
        {
            player.SwitchState(player.AttackState);
        }
        player.Anim.SetTrigger(ConstantClass.AnimIsIdle);

    }

    public override void UpdateState(Player player)
    {
     
    }
}
