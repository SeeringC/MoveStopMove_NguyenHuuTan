using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class PlayerBaseState
{
    public abstract void EnterState(Player player);
    public abstract void UpdateState(Player player);
}
