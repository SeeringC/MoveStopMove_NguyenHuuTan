using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PatrolState : BaseState
{
    public override void EnterState(Bot bot)
    {
        bot.ChangeAnim(ConstantClass.ANIM_RUN);

        if (bot.isDestionationReached)
        {
            bot.SetDestination(bot.GetRandomPosition());
        }

    }


    public override void UpdateState(Bot bot)
    {
        Debug.Log("current pos is: " + bot.m_transform.position);
        Debug.Log("target pos is: " + bot.des);
        Debug.Log("is target reached: " + bot.isDestionationReached);
        if (bot.isDestionationReached)
        {
            bot.SwitchState(bot.IdleState);
        }  

        //TODO:
        if (bot.IsCanAttack)
        {
            bot.SwitchState(bot.AttackState);

        }

    }
}
