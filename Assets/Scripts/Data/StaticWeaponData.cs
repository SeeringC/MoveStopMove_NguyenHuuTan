using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StaticWeaponData : ScriptableObject
{
    public List<StaticWeaponAttribute> StaticWeapons;
    public StaticWeaponAttribute GetData(StaticWeapon StaticWeapon)
    {
        return StaticWeapons[(int)StaticWeapon];
    }
}

[Serializable]
public class StaticWeaponAttribute
{
    public GameObject Prefab;
    public PoolType StaticWeaponType;
}

public enum StaticWeapon
{
    Arrow = 0,
    Axe_0 = 1,
    Axe_1 = 2,
    Boomerang = 3,
    Candy_0 = 4,
    Candy_1 = 5,
    Candy_2 = 6,
    Candy_4 = 7,
    Hammer = 8,
    Knife = 9,
    Uzi = 10,
    Z = 11,
}

