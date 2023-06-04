using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public float CountDownToAttack = 2f;
    public override void EnterState(Bot bot)
    {
        bot.Stop();
        bot.Attack();
    }

    public override void UpdateState(Bot bot)
    {
        CountDownToAttack -= Time.deltaTime;
        if (CountDownToAttack <= 0.1f)
        {
            CountDownToAttack = 2f;
            bot.SwitchState(bot.PatrolState);
        }
    }
}
