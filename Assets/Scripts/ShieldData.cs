using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShieldData : ScriptableObject
{
    public List<ShieldAttribute> shields;
    public ShieldAttribute GetData(Shield shield)
    {
        return shields[(int)shield];
    }

}

[Serializable]
public class ShieldAttribute
{
    public GameObject Prefab;
    public string ShieldName;

    public float GoldBonus;
    public int Price;
}

public enum Shield
{
   America_Shield,
   Medival_Shield,
}


