using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Rigidbody rb;

    public Animator anim;

    private Vector3 movementDirection;
    private Vector3 lookDirection;
    public float RotationSpeed;

    private bool isWalking;

    void Start()
    {
        anim = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    public override void Update()
    {
        ThrowWeapon();

        Move();
    }

    private void Move()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;
        lookDirection = new Vector3(horizontalInput, 0, verticalInput);

        Vector3 targetPosition = m_transform.position + lookDirection;
        m_transform.position = Vector3.MoveTowards(m_transform.position, targetPosition, 3 * Time.deltaTime);

        if (lookDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            m_transform.rotation = Quaternion.RotateTowards(m_transform.rotation, toRotation, RotationSpeed * Time.deltaTime);
        }
        anim.SetTrigger("isRun");



    }
    private void ThrowWeapon()
    {
        Debug.Log(AttackRange.TargetSet);
        if (AttackRange.enemiesInRange == null) return;
        if (!Input.GetKeyDown(KeyCode.T)) return;
        if (!AttackRange.TargetSet) return;

        GameObject ThrewWeapon = Instantiate(Weapon, m_transform.position, Quaternion.identity);
        ThrewWeapon.GetComponent<WeaponScript>().Target = AttackRange.enemiesInRange[0];
        anim.SetTrigger("isAttack");

    }



}
