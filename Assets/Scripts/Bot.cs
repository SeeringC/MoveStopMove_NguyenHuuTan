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
        currentState = PatrolState;
        currentState.EnterState(this);

        MapBound = Floor.GetComponent<Renderer>().bounds;

    }
    public override void Update()
    {
        base.Update();

        currentState.UpdateState(this);
        //Debug.Log(currentState);
        //Debug.Log("distance is" + Vector3.Distance(m_transform.position, destination));
        //Debug.Log("currnt pos is" + m_transform.position);
        //Debug.Log("currnt dest is" + destination);

        //Debug.Log(currentState);
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
    }   
    public void GetRandomPosition()
    {
        destination.x = Random.Range(MapBound.min.x, MapBound.max.x);
        destination.y = MapBound.max.y - 1f;
        destination.z = Random.Range(MapBound.min.z, MapBound.max.z);
        DestinationSet = true;
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
}
