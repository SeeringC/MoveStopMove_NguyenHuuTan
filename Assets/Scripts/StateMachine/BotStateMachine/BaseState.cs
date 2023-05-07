using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class BaseState
{
    public abstract void EnterState(Bot bot);
    public abstract void UpdateState(Bot bot);
}
