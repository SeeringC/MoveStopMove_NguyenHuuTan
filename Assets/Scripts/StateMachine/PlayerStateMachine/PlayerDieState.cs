using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        player.OnDespawn();
    }

    public override void UpdateState(Player player)
    {
        
    }
}
