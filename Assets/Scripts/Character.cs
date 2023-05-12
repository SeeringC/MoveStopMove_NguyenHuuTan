using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Character : GameUnit
{
    
    public List<Character> characterList = new();
    public UnityAction<Character> onDespawnCallback;

    public Transform m_transform;
    public AttackRangeScript AttackRange;

    public Animator Anim;

    public Weapon weapon;
    public WeaponData weaponData;

    public Pants pants;
    public PantsData pantsData;
    public GameObject GameObjectPants;

    public Transform Head;
    private GameObject Hair;
    public HairData hairData;
    public Hair hair;

    public Transform LeftHand;
    private GameObject Shield;
    public ShieldData shieldData;
    public Shield shield;

    public void ChangeWeapon(Weapon weapon)
    {
        AttackRange.WeaponType = weaponData.GetData(weapon).WeaponType;
    }

    public void ChangePants(Pants pants)
    {
        GameObjectPants.GetComponent<Renderer>().sharedMaterial = pantsData.GetData(pants).material;
    }

    public void ChangeHair(Hair hair)
    {
        Hair = hairData.GetData(hair).Prefab;
        Instantiate(Hair, Head);
    }

    public void ChangeShield(Shield shield)
    {
        Shield = shieldData.GetData(shield).Prefab;
        Instantiate(Shield, LeftHand);
    }

    public virtual void Start()
    {
        OnInit();
    }
    public virtual void Update()
    {
    }
    public override void OnDespawn()
    {

    }

    public override void OnInit()
    {
        m_transform = GetComponent<Transform>();
        AttackRange = transform.GetChild(3).GetComponent<AttackRangeScript>();
        Anim = GetComponent<Animator>();
        ChangeWeapon(weapon);
        ChangePants(pants);
        ChangeHair(hair);
        ChangeShield(shield);
    }


    public void Attack()
    {
        //Debug.Log(AttackRange.TargetSet);

        if (characterList.Count == 0) return;
        if (!AttackRange.TargetSet) return;
        Anim.SetTrigger(ConstantClass.AnimIsAttack);
        AttackRange.CThrowWeapon();
    }

    public IEnumerator CDespawn()
    {
        
        yield return Cache.GetWFS(3);
        Anim.SetTrigger(ConstantClass.AnimIsDead);
        this.gameObject.SetActive(false);
    }


    public void AddCharacter(Character character)
    {
        if (characterList.Contains(character)) return;
        characterList.Add(character);
        Debug.Log(character == null);
        /// Add function to call back
        character.onDespawnCallback += RemoveCharacter;
    }
    public void RemoveCharacter(Character character)
    {
        /// Debug.Log($"{gameObject.name} remove {character.gameObject.name}");
        if (!characterList.Contains(character)) return;
        characterList.Remove(character);

        /// Remove callback after character despawn
        onDespawnCallback -= character.RemoveCharacter;
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
        //StartCoroutine(CDespawn()); 
        onDespawnCallback?.Invoke(this);

        /// Clear all function in callback
        onDespawnCallback = null;
    }

}
