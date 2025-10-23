using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class IdleState : HunterState
{
  
    float timer = 0f;
    public IdleState(HunterController h) : base(h) { }

    public override void Enter()
    {
        timer = 0f;
        hunter.Velocity = Vector3.zero;
    }

    public override void UpdateState()
    {
     
        hunter.energy += hunter.energyRecoverIdle * Time.deltaTime;
        timer += Time.deltaTime;

        
        if (hunter.energy >= 30f || timer >= hunter.idleDurationSeconds)
        {
            hunter.energy = Mathf.Min(hunter.energy, 100f);
            hunter.TransitionToState(hunter.patrolState);
        }
    }

    public override void Exit() { }
}


