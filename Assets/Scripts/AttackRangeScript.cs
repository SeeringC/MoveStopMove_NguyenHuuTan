using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeScript : MonoBehaviour
{
    public bool TargetSet = false;
    public List<GameObject> enemiesInRange;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bot"))
        {
            enemiesInRange.Add(other.gameObject);
            TargetSet = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bot"))
        {
            enemiesInRange.Remove(other.gameObject);
        }

        if (enemiesInRange.Count == 0)
        {
            Debug.Log("it its null");
            TargetSet = false;
        }
    }
}
