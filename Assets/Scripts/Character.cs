using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;


//Fix Vibated bug by Lerp
//DotTween
//OdinInspector
public class Character : GameUnit
{
    
    public List<Character> characterList = new();
    public UnityAction<Character> onDespawnCallback;

    public Transform m_transform;
    public AttackRangeScript AttackRange;

    private string animName;
    public Animator Anim;

    public float MoveSpeed = 3f;

    public StaticWeapon staticWeapon;
    public Transform RightHand;
    public StaticWeaponData staticWeaponData;
    private GameObject StaticWeapon;

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

    public MissionWaypoint missionWaypoint;

    public Renderer Ren;
    public string CharName;
    public GameObject CharacterScale;
    public int Level;
    public bool IsCanAttack => (characterList.Count > 0 && AttackRange.TargetSet == true);
    public bool isPoweredUp = false;
    public virtual void Start()
    {
        
    }
    public virtual void Update()
    {

    }
    public override void OnDespawn()
    {
        missionWaypoint.gameObject.SetActive(false);
    }

    public override void OnInit()
    {
        m_transform = GetComponent<Transform>();
        //TODO: k dc dung getchild
        AttackRange = transform.GetChild(3).GetComponent<AttackRangeScript>();
        Anim = GetComponent<Animator>();

        GetItems();
        GetColor();
        Level = 1;

        WayPointSetUp();

    }

    public void ChangeWeapon(Weapon weapon)
    {
        AttackRange.WeaponType = weaponData.GetData(weapon).WeaponType;
        
        GetBonusAttackRange(weaponData.GetData(weapon).AttackRangeBonus);
        GetBonusAttackSpeed(weaponData.GetData(weapon).AttackSpeedBonus);

        StaticWeapon = staticWeaponData.GetData(((StaticWeapon)(int)weapon)).Prefab;
        Instantiate(StaticWeapon, RightHand);

    }

    public void ChangePants(Pants pants)
    {
        GameObjectPants.GetComponent<Renderer>().sharedMaterial = pantsData.GetData(pants).material;
        GetBonusMoveSpeed(pantsData.GetData(pants).BonusMoveSpeed);
    }

    public void ChangeHair(Hair hair)
    {
        Hair = hairData.GetData(hair).Prefab;

        Instantiate(Hair, Head);
        
        GetBonusAttackRange(hairData.GetData(hair).AttackRangeBonus);
       
    }

    public void ChangeShield(Shield shield)
    {
        Shield = shieldData.GetData(shield).Prefab;
        Instantiate(Shield, LeftHand);
    }

    
    public void Attack()
    {
        ChangeAnim(ConstantClass.ANIM_ATTACK);
        AttackRange.CThrowWeapon();
    }

    public IEnumerator CDespawn()
    {
        ChangeAnim(ConstantClass.ANIM_DIE);
        yield return Cache.GetWFS(3);
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
        //StartCoroutine(CDespawn()); 
        gameObject.SetActive(false);
        onDespawnCallback?.Invoke(this);

        /// Clear all function in callback
        onDespawnCallback = null;
    }

    public void GetBonusAttackRange(float BonusAttackRange)
    {
        
        Vector3 AttackRangeSize = AttackRange.AttackRangeAppearance.transform.localScale;
        float AttackRangeRadius = AttackRange.GetComponent<SphereCollider>().radius;

        AttackRange.AttackRangeAppearance.transform.localScale = AttackRangeSize + ((AttackRangeSize * BonusAttackRange)/100.0f);
        AttackRange.GetComponent<SphereCollider>().radius = AttackRangeRadius + ((AttackRangeRadius * BonusAttackRange)/100.0f);
    }

    public void GetBonusAttackSpeed(float BonusAttackSpeed)
    {
        float AttackSpeed = AttackRange.AttackSpeed;
        AttackRange.AttackSpeed = AttackSpeed - ((AttackSpeed * BonusAttackSpeed)/100.0f);
    }

    public void GetBonusMoveSpeed(float BonusMoveSpeed)
    {
        MoveSpeed = MoveSpeed + ((MoveSpeed * BonusMoveSpeed)/100.0f);
    }

    public void GetItems()
    {
        int PantsID = PlayerPrefs.GetInt(ConstantClass.SAVED_PANTS_ID);
        Pants pants = (Pants)PantsID;

        int HairID = PlayerPrefs.GetInt(ConstantClass.SAVED_HAIR_ID);
        Hair hair = (Hair)HairID;

        int ShieldID = PlayerPrefs.GetInt(ConstantClass.SAVED_SHIELD_ID);
        Shield shield = (Shield)ShieldID;

        int WeaponID = PlayerPrefs.GetInt(ConstantClass.SAVED_WEAPON_ID);
        Weapon weapon = (Weapon)WeaponID;

        ChangeWeapon((Weapon)WeaponID);
        ChangePants((Pants)PantsID);
        ChangeHair((Hair)HairID);
        ChangeShield((Shield)ShieldID);
    }

    public void GetColor()
    {
        Ren.material.color = Random.ColorHSV(.5f, 1f, 1f, 1f);
    }

    public void IncreaseLevel()
    {
        Level++;
        missionWaypoint.ChangeLevel(Level);
        if (ScaleIncreaseMileStone.LevelMileStone.Contains(Level))
        {
            float scaleIncrement = (Level * 0.2f + 1);
            CharacterScale.transform.localScale = (Level * 0.1f + 1) * Vector3.one;
            GetBonusAttackRange(scaleIncrement);
            GetBonusAttackSpeed(scaleIncrement);
            GetBonusMoveSpeed(scaleIncrement);
        }
    }
    
    public void WayPointSetUp()
    {
        missionWaypoint = SimplePool.Spawn<MissionWaypoint>(PoolType.MissionWaypoint, m_transform.position, Quaternion.identity);
        missionWaypoint.TargetPos = m_transform;
        missionWaypoint.Target = this;
        missionWaypoint.CharNameText.text = CharName;
        missionWaypoint.CharNameText.color = Ren.material.color;
        missionWaypoint.OnInit();
    }


    public void ChangeAnim(string AnimName)
    {
        if(this.animName!= AnimName)
        {
            Anim.ResetTrigger(this.animName);
            this.animName = AnimName;
            Anim.SetTrigger(AnimName);
        }
    }


    public void OnHit()
    {
        OnDeath();
    }

    public virtual void OnDeath()
    {
        if (this.CompareTag(ConstantClass.TAG_BOT))
        {
            Bot bot = this.GetComponent<Bot>();
            bot.SwitchState(bot.DieState);
        }

        if (this.CompareTag(ConstantClass.TAG_PLAYER))
        {
            Player player = this.GetComponent<Player>();
            player.ChangeState(player.DieState);
        }

        ParticlePool.Play(ParticleType.Hit, m_transform.position, Quaternion.identity);
        ChangeAnim(ConstantClass.ANIM_DIE);
        Invoke(nameof(Despawn), 1f);
    }

    public void PowerUp()
    {
        CharacterScale.transform.localScale = CharacterScale.transform.localScale * 1.5f;
        GetBonusAttackRange(50);
        GetBonusAttackSpeed(50);
        GetBonusMoveSpeed(50);
        isPoweredUp = true;
    }

    public void ResetPower()
    {
        if (isPoweredUp)
        {
            CharacterScale.transform.localScale = CharacterScale.transform.localScale / 1.5f;
            GetBonusAttackRange(-33);
            GetBonusAttackSpeed(-33);
            GetBonusMoveSpeed(-33);
            isPoweredUp = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstantClass.GIFTBOX))
        {
            PowerUp();
            Destroy(other.gameObject);
        }
    }
}
