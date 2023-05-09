using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : BaseState
{
    public override void EnterState(Bot bot)
    {
        bot.OnDespawn();
    }

    public override void UpdateState(Bot bot)
    {
        
    }
}
