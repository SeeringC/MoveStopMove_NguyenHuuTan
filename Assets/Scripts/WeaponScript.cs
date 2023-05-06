using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : GameUnit
{
    public GameObject Target;

    public GameObject ParentAttackRing;
    private Vector3 targetPosition;
    private void Start()
    {
        OnInit();
    }
    public override void OnDespawn()
    {
       
    }

    public override void OnInit()
    {
        
        targetPosition = Target.transform.position;
        Debug.Log(targetPosition);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstantClass.TagBot) || other.CompareTag(ConstantClass.TagPlayer))
        {
            
            
            ParentAttackRing.GetComponent<AttackRangeScript>().enemiesInRange.Remove(other.gameObject);
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            //Destroy(other.gameObject);
            //Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        
        if (Target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10 * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, targetPosition) > 0.1f) return;
        this.gameObject.SetActive(false);
    }
     
   

   

    
}
