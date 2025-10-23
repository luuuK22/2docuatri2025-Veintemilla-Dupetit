using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steering : MonoBehaviour
{
    
    public static Vector3 Seek(Vector3 position, Vector3 target, float maxSpeed)
    {
        Vector3 desired = target - position;
        if (desired.sqrMagnitude < 0.0001f) return Vector3.zero;
        return desired.normalized * maxSpeed;
    }

    public static Vector3 Arrive(Vector3 position, Vector3 target, float maxSpeed, float arriveRadius)
    {
        Vector3 toTarget = target - position;
        float dist = toTarget.magnitude;
        if (dist < 0.0001f) return Vector3.zero;
        float t = Mathf.Min(dist / arriveRadius, 1f);
        return toTarget.normalized * (maxSpeed * t);
    }

    
    public static Vector3 Evade(Vector3 position, Vector3 hunterPos, Vector3 hunterVel, float maxSpeed, float predictionTime = 1f)
    {
        Vector3 futureHunter = hunterPos + hunterVel * predictionTime;
        
        Vector3 away = position - futureHunter;
        if (away.sqrMagnitude < 0.0001f) return Random.insideUnitSphere.normalized * maxSpeed;
        return away.normalized * maxSpeed;
    }

  
    public static Vector3 Pursuit(Vector3 position, Vector3 targetPos, Vector3 targetVel, float maxSpeed)
    {
        float dist = Vector3.Distance(position, targetPos);
        float speed = Mathf.Max(maxSpeed, 0.001f);
        float t = dist / speed;
        Vector3 aim = targetPos + targetVel * t;
        return Seek(position, aim, maxSpeed);
    }
}


