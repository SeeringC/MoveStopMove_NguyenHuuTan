using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Rigidbody rb;


    private Vector3 movementDirection;
    private Vector3 lookDirection;
    public float RotationSpeed;


    public override void OnInit()
    {
        base.OnInit();

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Move();
    }

    private void Move()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;
        lookDirection = new Vector3(horizontalInput, 0, verticalInput);

        if (Vector3.Distance(lookDirection, Vector3.zero) < 0.1f)
        {
            SwitchState(IdleState);
            Anim.SetTrigger(ConstantClass.AnimIsIdle);
            Attack();
            return;
        }


        Vector3 targetPosition = m_transform.position + lookDirection;
        m_transform.position = Vector3.MoveTowards(m_transform.position, targetPosition, 3 * Time.deltaTime);

        if (Vector3.Distance(lookDirection, Vector3.zero) > 0.1f)
        {
            SwitchState(PatrolState);
            Quaternion toRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            m_transform.rotation = Quaternion.RotateTowards(m_transform.rotation, toRotation, RotationSpeed * Time.deltaTime);
            Anim.SetTrigger(ConstantClass.AnimIsRun);
        }
        
        
    }
    



}
