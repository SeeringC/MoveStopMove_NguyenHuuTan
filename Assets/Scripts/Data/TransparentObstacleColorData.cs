using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TransparentObstacleColorData : ScriptableObject
{
    public List<Material> mats;
    public Material GetData(TransparentObstacleColor transparentColor)
    {
        return mats[(int)transparentColor];
    }
}

public enum TransparentObstacleColor
{
    Wall = 0,
}