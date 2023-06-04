using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(Player player)
    {

        if (player.IsCanAttack)
        {
            player.ChangeState(player.AttackState);
        }
        player.ChangeAnim(ConstantClass.ANIM_IDLE);

    }

    public override void UpdateState(Player player)
    {
        player.GetJoystickInput();
    }
}
