using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PatrolState : BaseState
{
    public override void EnterState(Bot bot)
    {
        bot.Anim.SetTrigger(ConstantClass.AnimIsRun);

        if (!bot.DestinationSet)
        {
            bot.GetRandomPosition();
        }

        if (Vector3.Distance(bot.m_transform.position, bot.destination) < 1f)
        {
            bot.DestinationSet = false;
            Debug.Log("entered");
            bot.SwitchState(bot.IdleState);
            //bot.GetRandomPosition();
        }

        bot.Agent.SetDestination(bot.destination);
    }

    public override void UpdateState(Bot bot)
    {

        if (bot.AttackRange.enemiesInRange.Count == 0) return;
        if (!bot.AttackRange.TargetSet) return;

        bot.SwitchState(bot.AttackState);

    }
}
