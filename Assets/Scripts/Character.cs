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
