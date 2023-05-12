using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public float CountDown = 2f;
    public override void EnterState(Bot bot)
    {
        //bot.Agent.SetDestination(bot.m_transform.position);
        bot.Anim.SetTrigger(ConstantClass.AnimIsIdle);

        if (bot.characterList.Count == 0) return;
        if (!bot.AttackRange.TargetSet) return;

        bot.SwitchState(bot.AttackState);
        
    }

    public override void UpdateState(Bot bot)
    {
        bot.destination = bot.m_transform.position;

        CountDown -= Time.deltaTime;
        if (CountDown <= 0.1f)
        {
            bot.SwitchState(bot.PatrolState);
        }

    }
}
