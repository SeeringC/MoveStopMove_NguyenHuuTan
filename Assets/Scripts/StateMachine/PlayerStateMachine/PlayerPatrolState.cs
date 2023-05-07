using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerPatrolState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        player.Anim.SetTrigger(ConstantClass.AnimIsRun);
    }

    public override void UpdateState(Player player)
    {
        
        Vector3 targetPosition = player.m_transform.position + player.lookDirection;
        player.m_transform.position = Vector3.MoveTowards(player.m_transform.position, targetPosition, 3 * Time.deltaTime);
        Quaternion toRotation = Quaternion.LookRotation(player.lookDirection, Vector3.up);

        player.m_transform.rotation = Quaternion.RotateTowards(player.m_transform.rotation, toRotation, player.RotationSpeed * Time.deltaTime);
    }
}
