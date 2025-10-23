using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class HunterController : MonoBehaviour
{
   
    [Header("Movement")]
    public float maxSpeed = 6f;
    [HideInInspector] public Vector3 Velocity;

    [Header("Energy")]
    public float energy = 100f;
    public float energyDrainPatrol = 2f;
    public float energyDrainHunt = 8f; 
    public float energyRecoverIdle = 25f;
    public float idleDurationSeconds = 3f;

    [Header("Perception")]
    public float viewRadius = 12f;
    public LayerMask boidMask;

    [Header("Waypoints")]
    public List<Transform> waypoints = new List<Transform>();
    public bool loopWaypoints = true;
    public bool reverseOnEnd = false;

    [Header("Shooting")]
    public Gun gun;

    // State
    HunterState currentState;
    public IdleState idleState;
    public PatrolState patrolState;
    public HuntingState huntingState;

   
    public BoidManager manager;

    void Awake()
    {
        manager = FindObjectOfType<BoidManager>();
        manager.hunter = this;
    }

    void Start()
    {
        idleState = new IdleState(this);
        patrolState = new PatrolState(this);
        huntingState = new HuntingState(this);

       
        TransitionToState(patrolState);
    }

    void Update()
    {
        currentState?.UpdateState();


        transform.position += Velocity * Time.deltaTime;
        if (Velocity.sqrMagnitude > 0.0001f)
            transform.forward = Vector3.Slerp(transform.forward, Velocity.normalized, Time.deltaTime * 8f);
    }

    public void TransitionToState(HunterState newState)
    {
        if (currentState != null) currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

  
    public BoidController GetClosestBoidInView()
    {
        BoidController closest = null;
        float minSqr = viewRadius * viewRadius;
        foreach (var b in manager.boids)
        {
            if (b == null) continue;
            float d2 = (b.Position - transform.position).sqrMagnitude;
            if (d2 <= minSqr)
            {
                if (closest == null || d2 < (closest.Position - transform.position).sqrMagnitude)
                    closest = b;
            }
        }
        return closest;
    }
}


