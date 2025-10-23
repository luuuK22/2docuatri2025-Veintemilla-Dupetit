using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HunterState : MonoBehaviour
{
    
        protected HunterController hunter;
        public HunterState(HunterController h) { hunter = h; }
        public abstract void Enter();
        public abstract void UpdateState();
        public abstract void Exit();
    }


