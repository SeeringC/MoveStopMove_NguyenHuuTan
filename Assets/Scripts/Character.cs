using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public Transform m_transform;
    public AttackRangeScript AttackRange;
    public GameObject Weapon;

    private void Start()
    {
    }
    public virtual void  Update()
    {
    }

    
    private void OnDestroy()
    {
        AttackRange.enemiesInRange.Remove(this.gameObject);
    }

    private void Attack()
    {
        
    }
}
