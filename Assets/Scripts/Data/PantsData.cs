using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PantsData : ScriptableObject
{
   
    public List<PantsAttribute> PantsList;
    public PantsAttribute GetData(Pants pants)
    {
            return PantsList[(int)pants];
    }
}

[Serializable]
public class PantsAttribute
{
    public Material material;
    public string PantsName;
    public Sprite PantSprite;
    public int BonusMoveSpeed;
    public int Price;
}

public enum Pants
{
    Batman,
    Chambi,
    Comy,
    Dabao,
    Onion,
    Pokemon,
    RainBow,
    Skull,
    Vantim,
}
