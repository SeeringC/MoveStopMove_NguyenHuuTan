using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HairData : ScriptableObject
{
    public List<HairAttribute> hairs;
    public HairAttribute GetData(Hair hair)
    {
        return hairs[(int)hair];
    }

}

[Serializable]
public class HairAttribute
{
    public GameObject Prefab;
    public string HairName;
    public Sprite HairSprite;
    public float AttackRangeBonus;
    public int Price;
}

public enum Hair
{
    Arrow,
    Cowboy,
    Crown,
    Ear,
    Hat,
    Hat_Cap,
    Hat_Yeallow,
    Headphone,
    Horn,
    Rau,
}


