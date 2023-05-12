using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public List<WeaponAttribute> weapons;
    public WeaponAttribute GetData(Weapon weapon)
    {
        return weapons[(int)weapon];
    }

}

[Serializable]
public class WeaponAttribute
{
    public GameObject Prefab;
    public string WeaponName;
    //public string WeaponType;
    public float AttackRange;
    public int Price;
    public PoolType WeaponType;
    
}

public enum Weapon
{
    Arrow,
    Axe_0,
    Axe_1,
    Boomerang,
    Candy_0,
    Candy_1,
    Candy_2,
    Candy_4,
    Hammer,
    Knife,
    Uzi,
    Z,
}


