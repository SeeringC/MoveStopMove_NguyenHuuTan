using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{

    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Rigidbody rb;

    PlayerBaseState currentState;
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerPatrolState PatrolState = new PlayerPatrolState();
    public PlayerAttackState AttackState = new PlayerAttackState();
    public PlayerDieState DieState = new PlayerDieState();

    public Vector3 lookDirection;
    public float RotationSpeed;
    public float horizontalInput;
    public float verticalInput;

    public override void Start()
    {
        base.Start();
        currentState = IdleState;
        currentState.EnterState(this);
        SwitchState(IdleState);
    }
   
    public override void Update()
    {
        base.Update();
        GetJoystickInput();
        currentState.UpdateState(this);

    }
    public override void OnInit()
    {
        base.OnInit();

    }

    public override void OnDespawn()
    {
        base.OnDespawn();
    }
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    private void GetJoystickInput()
    {
        horizontalInput = joystick.Horizontal;
        verticalInput = joystick.Vertical;
        lookDirection = new Vector3(horizontalInput, 0, verticalInput);


        if (Vector3.Distance(lookDirection, Vector3.zero) < 0.1f)
        {
            SwitchState(IdleState);
        }

        if (Vector3.Distance(lookDirection, Vector3.zero) > 0.1f)
        {
            SwitchState(PatrolState);
        }
    }
    



}
