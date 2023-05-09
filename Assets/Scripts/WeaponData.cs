using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public List<WeaponData> weapons;

    public GameObject Prefab;
    public string WeaponName;
    public string WeaponType;
    public int Damage;
    public float AttackRange;
}

