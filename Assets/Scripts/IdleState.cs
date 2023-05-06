using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public float CountDown = 2f;
    public override void EnterState(Bot bot)
    {
        bot.destination = bot.m_transform.position;

        if (bot.AttackRange.enemiesInRange.Count == 0) return;
        if (!bot.AttackRange.TargetSet) return;

        bot.SwitchState(bot.AttackState);
        
        //bot.SwitchState(bot.PatrolState);
        //bot.GetRandomPosition();
    }

    public override void UpdateState(Bot bot)
    {
        //bot.Anim.SetTrigger(ConstantClass.AnimIsIdle);
        CountDown -= Time.deltaTime;
        if (CountDown <= 0)
        {
            bot.SwitchState(bot.PatrolState);
            //bot.GetRandomPosition();
        }

    }
}
