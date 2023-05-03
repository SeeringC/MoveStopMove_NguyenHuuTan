using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class BaseState
{
    public abstract void EnterState(Character character);
    public abstract void UpdateState(Character character);
}
