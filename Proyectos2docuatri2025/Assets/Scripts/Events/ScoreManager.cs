using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
   
    public int score;

    private void OnEnable()
    {
        EventManager.Subscribe(EventType.OnEnemyDead, AddPoint);
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(EventType.OnEnemyDead, AddPoint);
    }

    void AddPoint()
    {
        score++;
        EventManager.Trigger(EventType.OnScoreChanged);
    }
}


