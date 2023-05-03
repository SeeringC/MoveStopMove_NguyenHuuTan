using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackRangeScript : MonoBehaviour
{
    ObjectPooler projectilePooler;

    public Transform m_transform;
    public GameObject Character;
    public bool TargetSet = false;
    public List<GameObject> enemiesInRange;
    public GameObject Weapon;
    private void Start()
    {
        projectilePooler = ObjectPooler.Instance;
    }
    private void Update()
    {
        
    }
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

        if (enemiesInRange == null)
        {
            Debug.Log("it its null");
            TargetSet = false;
        }
    }

    public void ThrowWeapon()
    {
        TargetSet = false;
        GameObject ThrewWeapon = projectilePooler.SpawnFromPool("Projectile", m_transform.position, Quaternion.identity);
        ThrewWeapon.GetComponent<WeaponScript>().Target = enemiesInRange[0];
    }

    //public bool EnemyHit()
    //{

    //}
}
