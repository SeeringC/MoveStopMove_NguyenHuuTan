using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        player.Attack();

    }

    public override void UpdateState(Player player)
    {
        player.GetJoystickInput();
    }
}
