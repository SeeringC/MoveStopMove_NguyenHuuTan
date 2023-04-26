using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject Target;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bot"))
        {
            Destroy(other.gameObject);
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
