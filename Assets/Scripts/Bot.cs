using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    public NavMeshAgent Agent;
    public GameObject Floor;
    public Bounds MapBound;
    private Vector3 destination;
    public bool DestinationSet = false;
    public bool AttackAble = false;

    public override void OnDespawn()
    {

    }

    public override void OnInit()
    {

    }
    public override void Start()
    {
        base.Start();
        MapBound = Floor.GetComponent<Renderer>().bounds;
    }
    public override void Update()
    {
        base.Update();
        MoveAgent();
        CheckToAttack();
    }

    public void MoveAgent()
    {
        if (!DestinationSet)
        {
            GetRandomPosition();
            DestinationSet = true;
        }

        if (Vector3.Distance(m_transform.position, destination) < 0.1f)
        {
            Anim.SetTrigger(ConstantClass.AnimIsIdle);
            SwitchState(IdleState);
            GetRandomPosition();
        }

        Agent.SetDestination(destination);
        SwitchState(PatrolState);
        Anim.SetTrigger(ConstantClass.AnimIsRun);
        


    }
    public void GetRandomPosition()
    {
        destination.x = Random.Range(MapBound.min.x, MapBound.max.x);
        destination.y = MapBound.max.y;
        destination.z = Random.Range(MapBound.min.z, MapBound.max.z);
    }

    public void CheckToAttack()
    {
        if (AttackRange.enemiesInRange.Count == 0) return;
        
        //Agent.isStopped = true;
        Attack();
    }
}
