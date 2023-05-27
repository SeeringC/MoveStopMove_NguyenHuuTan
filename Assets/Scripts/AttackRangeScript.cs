using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class AttackRangeScript : MonoBehaviour
{

    public PoolType WeaponType;
    public Transform m_transform;
    public Character character;
    public bool TargetSet = false;
    public GameObject AttackRangeAppearance;
    public float AttackSpeed = 3;
    //public List<Character> enemiesInRange = new();
    public TargetRingScript TargetRing;
    public Transform WeaponSpawnLocation;
    private void Start()
    {  
        
    }
    //private void Update()
    //{
        
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstantClass.TagBot) || other.CompareTag(ConstantClass.TagPlayer))
        {
            //enemiesInRange.Add(other.gameObject);
            Character tempChar = Cache.GetCharacter(other);
            //Character tempChar = other.GetComponent<Character>();
            character.AddCharacter(tempChar);
            TargetSet = true;

            if (character.CompareTag(ConstantClass.TagBot)) return;
            TargetRing.gameObject.SetActive(true);
            Character Target = character.characterList[0];
            TargetRing.Target = Target;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(ConstantClass.TagBot) || other.CompareTag(ConstantClass.TagPlayer))
        {
            //enemiesInRange.Remove(other.gameObject);
            //Character tempChar = other.GetComponent<Character>();
            Character tempChar = Cache.GetCharacter(other);

            character.RemoveCharacter(tempChar);

            if (character.CompareTag(ConstantClass.TagBot)) return;

            if (character.characterList.Count > 0)
            {
                Character Target = character.characterList[0];
                TargetRing.Target = Target;
            }

            else
            {
                TargetRing.gameObject.SetActive(false);
            }


        }

        if (character.characterList.Count == 0)
        {

            TargetSet = false;
        }
    }

    public IEnumerator ThrowWeapon()
    {
        TargetSet = false;
        Character Target = character.characterList[0];
        character.m_transform.LookAt(Target.m_transform);
        WeaponScript weaponScript = SimplePool.Spawn<WeaponScript>(WeaponType, WeaponSpawnLocation.position, Quaternion.identity);
        weaponScript.ParentAttackRing = this;
        weaponScript.Target = Target.gameObject;


        yield return Cache.GetWFS(AttackSpeed);

        if (character.characterList.Count > 0)
        {
            weaponScript.Target = Target.gameObject;
            TargetSet = true;
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
