using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        player.ResetJoyStick();
        player.ChangeAnim(ConstantClass.ANIM_DIE);
    }

    public override void UpdateState(Player player)
    {
        
    }
}
