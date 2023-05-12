using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public float CountDownToAttack = 2f;
    public override void EnterState(Bot bot)
    {
        bot.Attack();


        //bot.CResumeAgent();
        //bot.SwitchState(bot.PatrolState);
    }

    public override void UpdateState(Bot bot)
    {
        bot.destination = bot.m_transform.position;

        CountDownToAttack -= Time.deltaTime;
        if (CountDownToAttack <= 0.1f)
        {
            bot.SwitchState(bot.PatrolState);
        }
    }
}
