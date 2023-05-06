using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackRangeScript : MonoBehaviour
{

    public Transform m_transform;
    public GameObject Character;
    public bool TargetSet = false;
    public List<GameObject> enemiesInRange = new();
    public GameObject Weapon;
    public Transform WeaponSpawnLocation;
    //private void Start()
    //{
        
    //}
    //private void Update()
    //{
        
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstantClass.TagBot) || other.CompareTag(ConstantClass.TagPlayer))
        {
            enemiesInRange.Add(other.gameObject);
            TargetSet = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(ConstantClass.TagBot) || other.CompareTag(ConstantClass.TagPlayer))
        {
            enemiesInRange.Remove(other.gameObject);
        }

        if (enemiesInRange.Count == 0)
        {
            

            TargetSet = false;
        }
    }

    public IEnumerator ThrowWeapon()
    {
        TargetSet = false;
        Character.transform.LookAt(enemiesInRange[0].transform);
        WeaponScript weaponScript = SimplePool.Spawn<WeaponScript>(PoolType.Brick, WeaponSpawnLocation.position, Quaternion.identity);
        weaponScript.ParentAttackRing = this.gameObject;
        weaponScript.Target = enemiesInRange[0];
        
        yield return Cache.GetWFS(4);

        if (enemiesInRange.Count > 0)
        {
            weaponScript.Target = enemiesInRange[0];

        }
    }

    public void CThrowWeapon()
    {
        StartCoroutine(ThrowWeapon());
    }

    //public bool EnemyHit()
    //{

    //}
}
