using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class HuntingState : HunterState
{
   
    BoidController target;
    float lostTimer = 0f;
    public HuntingState(HunterController h) : base(h) { }

    public override void Enter()
    {
        target = hunter.GetClosestBoidInView();
        lostTimer = 0f;
    }

    public override void UpdateState()
    {
        if (target == null)
        {
         
            target = hunter.GetClosestBoidInView();
            if (target == null)
            {
                lostTimer += Time.deltaTime;
                if (lostTimer >= 1.2f) { hunter.TransitionToState(hunter.patrolState); return; }
            }
        }

        if (target != null)
        {
          
            Vector3 desired = steering.Pursuit(hunter.transform.position, target.Position, target.Velocity, hunter.maxSpeed);
            hunter.Velocity = Vector3.Lerp(hunter.Velocity, desired, Time.deltaTime * 4f);

          
            hunter.energy -= hunter.energyDrainHunt * Time.deltaTime;
            if (hunter.energy <= 0f)
            {
                hunter.energy = 0f;
                hunter.TransitionToState(hunter.idleState);
                return;
            }

            
            if (hunter.gun != null)
            {
                float dist = Vector3.Distance(hunter.transform.position, target.Position);
                if (dist <= hunter.gun.shootRange)
                {
                    hunter.gun.TryShootAt(target);
                }
            }

            float d2 = (target.Position - hunter.transform.position).sqrMagnitude;
            if (d2 > hunter.viewRadius * hunter.viewRadius)
            {
                lostTimer += Time.deltaTime;
                if (lostTimer > 1.0f)
                {
                    hunter.TransitionToState(hunter.patrolState);
                    return;
                }
            }
            else lostTimer = 0f;
        }
    }

    public override void Exit()
    {
        target = null;
    }
}


