using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameUnit
{

    BaseState currentState;
    public IdleState IdleState = new IdleState();
    public PatrolState PatrolState = new PatrolState();
    public AttackState AttackState = new AttackState();

    public Transform m_transform;
    public AttackRangeScript AttackRange;
    public Animator Anim;

    public override void OnDespawn()
    {

    }

    public override void OnInit()
    {
        m_transform = GetComponent<Transform>();
        AttackRange = transform.GetChild(0).GetComponent<AttackRangeScript>();


    }
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

  

    protected void Attack()
    {
        SwitchState(AttackState);
        
        if (AttackRange.enemiesInRange == null) return;
        if (!AttackRange.TargetSet) return;

        AttackRange.CThrowWeapon(); 
        Anim.SetTrigger(ConstantClass.AnimIsAttack);

    }
}
