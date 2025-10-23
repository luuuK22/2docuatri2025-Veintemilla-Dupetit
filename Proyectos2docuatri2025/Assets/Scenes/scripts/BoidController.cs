using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour
{
    
    [Header("Boid - Movement")]
    public float maxSpeed = 4.5f;
    public float wanderStrength = 1.2f;

    [Header("Perception")]
    public float viewRadius = 8f;
    public float arriveRadius = 1.2f;
    public float separationDistance = 1f;

    [HideInInspector] public Vector3 Velocity;

    BoidManager manager;

    void Start()
    {
        manager = FindObjectOfType<BoidManager>();
   
        Velocity = transform.forward * (maxSpeed * 0.5f);
    }

    void Update()
    {
       
        GameObject food = manager.GetClosestFood(transform.position, viewRadius);
        HunterController hunter = manager.GetHunterInView(transform.position, viewRadius);
        List<BoidController> neighbors = manager.GetNeighbors(this, viewRadius);

        Vector3 targetSteer = Vector3.zero;
        if (food != null)
        {
          
            targetSteer = steering.Arrive(transform.position, food.transform.position, maxSpeed, arriveRadius);
           
        }
        else if (hunter != null)
        {
          
            targetSteer = steering.Evade(transform.position, hunter.transform.position, hunter.Velocity, maxSpeed, 1f);
        }
        else if (neighbors != null && neighbors.Count > 1)
        {
          
            Vector3 s = flocking.Separation(this, neighbors, separationDistance, maxSpeed) * 1.6f;
            Vector3 a = flocking.Alignment(this, neighbors, maxSpeed) * 1.0f;
            Vector3 c = flocking.Cohesion(this, neighbors, maxSpeed) * 1.0f;
            targetSteer = s + a + c;
            if (targetSteer.sqrMagnitude < 0.0001f)
                targetSteer = manager.GetRandomWanderVelocity(transform.position, maxSpeed) * 0.5f;
        }
        else
        {
            targetSteer = manager.GetRandomWanderVelocity(transform.position, maxSpeed) * wanderStrength;
        }

       
        Velocity = Vector3.Lerp(Velocity, targetSteer, Time.deltaTime * 3f);
        if (Velocity.magnitude > maxSpeed) Velocity = Velocity.normalized * maxSpeed;
        transform.position += Velocity * Time.deltaTime;

       
        if (Velocity.sqrMagnitude > 0.0001f)
            transform.forward = Vector3.Slerp(transform.forward, Velocity.normalized, Time.deltaTime * 8f);
    }

    public Vector3 Position => transform.position;
}


