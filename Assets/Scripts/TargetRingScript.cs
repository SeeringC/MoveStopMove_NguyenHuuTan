using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRingScript : GameUnit 
{
    public Character Target;

    private void Update()
    {
        transform.position = Target.transform.position;
    }
}
