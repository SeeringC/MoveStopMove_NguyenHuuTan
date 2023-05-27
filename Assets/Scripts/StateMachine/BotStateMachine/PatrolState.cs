using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PatrolState : BaseState
{
    public override void EnterState(Bot bot)
    {
        bot.ChangeAnim(ConstantClass.AnimIsRun);

        if (!bot.DestinationSet)
        {
            bot.GetRandomPosition();
        }

        bot.Agent.SetDestination(bot.destination);
        bot.DestinationSet = true;
    }

    public override void UpdateState(Bot bot)
    {
        if (Vector3.Distance(bot.m_transform.position, bot.destination) < 0.3f)
        {
            bot.DestinationSet = false;
            bot.SwitchState(bot.IdleState);
            //bot.GetRandomPosition();
        }

        if (bot.characterList.Count == 0) return;
        if (!bot.AttackRange.TargetSet) return;
    
        bot.SwitchState(bot.AttackState);

    }
}
