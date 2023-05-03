using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    BaseState currentState;
    public IdleState IdleState = new IdleState();
    public PatrolState PatrolState = new PatrolState();
    public AttackState AttackState = new AttackState();

    public Transform m_transform;
    public AttackRangeScript AttackRange;
    public Animator Anim;


    public virtual void Start()
    {
        Anim = GetComponent<Animator>();
        currentState = IdleState;
        currentState.EnterState(this);

    }
    public virtual void  Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnDestroy()
    {
        AttackRange.enemiesInRange.Remove(this.gameObject);
    }

    protected void Attack()
    {
        SwitchState(AttackState);
        Debug.Log(AttackRange.TargetSet);
        if (AttackRange.enemiesInRange == null) return;
        //if (!Input.GetKeyDown(KeyCode.T)) return;
        if (!AttackRange.TargetSet) return;

        AttackRange.ThrowWeapon();
        Anim.SetTrigger("isAttack");

    }
}
