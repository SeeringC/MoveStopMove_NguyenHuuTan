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
    public Sprite WeaponSprite;
    public int AttackRangeBonus;
    public int Price;
    public PoolType WeaponType;
    
}

public enum Weapon
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


