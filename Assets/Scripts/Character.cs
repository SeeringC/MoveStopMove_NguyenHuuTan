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

    public float MoveSpeed = 3f;

    public Weapon weapon;
    public WeaponData weaponData;

    public Pants pants;
    public PantsData pantsData;
    public GameObject GameObjectPants;

    public Hair hair;
    public Transform Head;
    private GameObject Hair;
    public HairData hairData;

    public Shield shield;
    public Transform LeftHand;
    private GameObject Shield;
    public ShieldData shieldData;

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

        int PantsID = PlayerPrefs.GetInt("SavedPantsID");
        Pants pants = (Pants)PantsID;

        int HairID = PlayerPrefs.GetInt("SavedHairID");
        Hair hair = (Hair)HairID;

        int ShieldID = PlayerPrefs.GetInt("SavedShieldID");
        Shield shield = (Shield)ShieldID;

        int WeaponID = PlayerPrefs.GetInt("SavedWeaponID");
        Weapon weapon = (Weapon)WeaponID;

        ChangeWeapon((Weapon)WeaponID);
        ChangePants((Pants)PantsID);
        ChangeHair((Hair)HairID);
        ChangeShield((Shield)ShieldID);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        AttackRange.WeaponType = weaponData.GetData(weapon).WeaponType;

        GetBonusAttackRange();
        GetBonusAttackSpeed();
    }

    public void ChangePants(Pants pants)
    {
        GameObjectPants.GetComponent<Renderer>().sharedMaterial = pantsData.GetData(pants).material;
        GetBonusMoveSpeed();
    }

    public void ChangeHair(Hair hair)
    {
        Hair = hairData.GetData(hair).Prefab;
        Instantiate(Hair, Head);

        GetBonusAttackRange();
       
    }

    public void ChangeShield(Shield shield)
    {
        Shield = shieldData.GetData(shield).Prefab;
        Instantiate(Shield, LeftHand);
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

    public void GetBonusAttackRange()
    {
        //attack range
        float BonusAttackRange = hairData.GetData(hair).AttackRangeBonus / 100.0f;
        Vector3 AttackRangeSize = AttackRange.AttackRangeAppearance.transform.localScale;
        float AttackRangeRadius = AttackRange.GetComponent<SphereCollider>().radius;

        AttackRange.AttackRangeAppearance.transform.localScale = AttackRangeSize + AttackRangeSize * BonusAttackRange;
        AttackRange.GetComponent<SphereCollider>().radius = AttackRangeRadius + AttackRangeRadius * BonusAttackRange;
    }

    public void GetBonusAttackSpeed()
    {
        float BonusAttackSpeed = weaponData.GetData(weapon).AttackSpeedBonus / 100.0f;
        float AttackSpeed = AttackRange.AttackSpeed;
        AttackRange.AttackSpeed = AttackSpeed - (AttackSpeed * BonusAttackSpeed);
    }

    public void GetBonusMoveSpeed()
    {
        float BonusMoveSpeed = pantsData.GetData(pants).BonusMoveSpeed / 100.0f;
        MoveSpeed = MoveSpeed + (MoveSpeed * BonusMoveSpeed);
    }

}
