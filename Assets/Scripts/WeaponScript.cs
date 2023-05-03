using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour, IPooledObject
{
    public GameObject Target;

    public void OnObjectSpawn()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bot"))
        {
            //Debug.Log("target is:" + transform.parent.GetComponent<AttackRangeScript>().TargetSet);

            //transform.parent.GetComponent<AttackRangeScript>().TargetSet = true;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        Debug.Log(Target);
        if (Target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 10 * Time.deltaTime);
        }
    }

    
}
