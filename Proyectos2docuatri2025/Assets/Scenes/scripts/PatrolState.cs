using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PatrolState : HunterState
{
    
    int currentIndex = 0;
    bool forward = true;
    public PatrolState(HunterController h) : base(h) { }

    public override void Enter()
    {
        // default index
        if (hunter.waypoints == null || hunter.waypoints.Count == 0)
        {
            hunter.Velocity = Vector3.zero;
            return;
        }
    }

    public override void UpdateState()
    {
        if (hunter.waypoints == null || hunter.waypoints.Count == 0) return;

        Transform targetWP = hunter.waypoints[currentIndex];
        // usar Arrive para llegar al waypoint
        Vector3 desired = steering.Arrive(hunter.transform.position, targetWP.position, hunter.maxSpeed, 1.2f);
        hunter.Velocity = Vector3.Lerp(hunter.Velocity, desired, Time.deltaTime * 3f);

        // energy drain while moving
        hunter.energy -= hunter.energyDrainPatrol * Time.deltaTime;
        if (hunter.energy <= 0f)
        {
            hunter.energy = 0f;
            hunter.TransitionToState(hunter.idleState);
            return;
        }

        // detectar boid en vista -> cambiar a hunting
        BoidController found = hunter.GetClosestBoidInView();
        if (found != null)
        {
            hunter.TransitionToState(hunter.huntingState);
            return;
        }

        // llegar al waypoint?
        if (Vector3.Distance(hunter.transform.position, targetWP.position) < 1.0f)
        {
            // avanzar índice
            if (hunter.reverseOnEnd && !hunter.loopWaypoints)
            {
                if (forward)
                {
                    currentIndex++;
                    if (currentIndex >= hunter.waypoints.Count) { currentIndex = hunter.waypoints.Count - 1; forward = false; }
                }
                else
                {
                    currentIndex--;
                    if (currentIndex < 0) { currentIndex = 0; forward = true; }
                }
            }
            else
            {
                currentIndex++;
                if (currentIndex >= hunter.waypoints.Count)
                {
                    if (hunter.loopWaypoints) currentIndex = 0;
                    else
                    {
                        if (hunter.reverseOnEnd) { currentIndex = hunter.waypoints.Count - 1; forward = false; }
                        else currentIndex = 0;
                    }
                }
            }
        }
    }

    public override void Exit() { }
}


