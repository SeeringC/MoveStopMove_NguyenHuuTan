using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class AttackRangeScript : MonoBehaviour
{

    public Transform m_transform;
    public Character character;
    public bool TargetSet = false;
    //public List<Character> enemiesInRange = new();
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
            //enemiesInRange.Add(other.gameObject);
            Character tempChar = Cache.GetCharacter(other);
            //Character tempChar = other.GetComponent<Character>();
            character.AddCharacter(tempChar);
            TargetSet = true;
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

        }

        if (character.characterList.Count == 0)
        {

            TargetSet = false;
        }
    }

    public IEnumerator ThrowWeapon()
    {
        TargetSet = false;
        character.transform.LookAt(character.characterList[0].transform);
        WeaponScript weaponScript = SimplePool.Spawn<WeaponScript>(PoolType.Brick, WeaponSpawnLocation.position, Quaternion.identity);
        weaponScript.ParentAttackRing = this.gameObject;
        weaponScript.Target = character.characterList[0].GetComponent<Character>().gameObject;
        
        yield return Cache.GetWFS(2);

        if (character.characterList.Count > 0)
        {
            weaponScript.Target = character.characterList[0].GetComponent<Character>().gameObject;
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
