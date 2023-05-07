using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public float CountDownToAttack = 4f;
    public override void EnterState(Bot bot)
    {
        bot.destination = bot.m_transform.position;
        bot.Attack();


        //bot.CResumeAgent();
        //bot.SwitchState(bot.PatrolState);
    }

    public override void UpdateState(Bot bot)
    {
        
        CountDownToAttack -= Time.deltaTime;
        if (CountDownToAttack <= 0f)
        {
            bot.SwitchState(bot.PatrolState);
        }
    }
}
