using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SolidObstacleColorData : ScriptableObject
{
    public List<Material> mats;
    public Material GetData(SolidObstacleColor SolidColor)
    {
        return mats[(int)SolidColor];   
    }
}

public enum SolidObstacleColor
{
    Wall = 0,
}
