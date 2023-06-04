using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public float CountDown = 2f;
    public override void EnterState(Bot bot)
    {
        bot.ChangeAnim(ConstantClass.ANIM_IDLE);
        bot.Stop();

        if (bot.IsCanAttack)
        {
            bot.SwitchState(bot.AttackState);
        }


    }

    public override void UpdateState(Bot bot)
    {

        CountDown -= Time.deltaTime;
        if (CountDown <= 0.1f)
        {
            CountDown = 2f;
            bot.SwitchState(bot.PatrolState);
        }

    }
}
