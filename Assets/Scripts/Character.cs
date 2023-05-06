using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : GameUnit
{

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



    }
    public virtual void  Update()
    {
    }

    

  

    public void Attack()
    {
        //Debug.Log(AttackRange.TargetSet);

        if (AttackRange.enemiesInRange.Count == 0) return;
        if (!AttackRange.TargetSet) return;
        Anim.SetTrigger(ConstantClass.AnimIsAttack);

        AttackRange.CThrowWeapon();
    }
}
