using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Bot : Character
{
    BaseState currentState;
    public IdleState IdleState = new IdleState();
    public PatrolState PatrolState = new PatrolState();
    public AttackState AttackState = new AttackState();
    public DieState DieState = new DieState();

    public NavMeshAgent Agent;
    public GameObject Floor;

    public Bounds MapBound;
    public Vector3 destination;
    public bool DestinationSet = false;
    public bool AttackAble = false;




    public override void Start()
    {
        base.Start();
        OnInit();
        currentState = IdleState;
        currentState.EnterState(this);

        MapBound = Floor.GetComponent<Renderer>().bounds;

    }
    public override void Update()
    {
        base.Update();
        currentState.UpdateState(this);
    }
    public override void OnDespawn()
    {
        base.OnDespawn();
    }

    public override void OnInit()
    {
        NameList.AddName(ref CharName);
        base.OnInit();
        Agent.speed = MoveSpeed;
        currentState = IdleState;
        this.des = new Vector3(m_transform.position.x, 0f, m_transform.position.z);
    }   


    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    //public IEnumerator ResumeAgent()
    //{
    //    yield return Cache.GetWFS(3);
    //    Agent.isStopped = false;
    //}

    //public void CResumeAgent()
    //{
    //    StartCoroutine(ResumeAgent());
    //}


    public Vector3 des;

    public bool isDestionationReached => Vector3.Distance(m_transform.position, des) < 0.3f;

    public Vector3 GetRandomPosition()
    {
        des.x = Random.Range(MapBound.min.x, MapBound.max.x);
        des.y = 0;
        des.z = Random.Range(MapBound.min.z, MapBound.max.z);
        return des;
        //DestinationSet = true;
        //TODO: navmesh.sampleposition

        //SetDestination(destination);
    }
    public void SetDestination(Vector3 point)
    {
        this.des = point;
        Agent.SetDestination(des);
    }

    public void Stop()
    {
        this.des = m_transform.position;
        Agent.SetDestination(des);
    }
}
