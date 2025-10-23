using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flocking : MonoBehaviour
{
    
    public static Vector3 Separation(BoidController self, List<BoidController> neighbors, float separationDistance, float maxSpeed)
    {
        Vector3 force = Vector3.zero;
        int count = 0;
        foreach (var b in neighbors)
        {
            if (b == self) continue;
            Vector3 diff = self.Position - b.Position;
            float d = diff.magnitude;
            if (d < separationDistance && d > 0.0001f)
            {
                force += diff.normalized / d; 
                count++;
            }
        }
        if (count == 0) return Vector3.zero;
        force /= count;
        if (force.sqrMagnitude < 0.0001f) return Vector3.zero;
        return force.normalized * maxSpeed;
    }

    public static Vector3 Alignment(BoidController self, List<BoidController> neighbors, float maxSpeed)
    {
        Vector3 avg = Vector3.zero;
        int count = 0;
        foreach (var b in neighbors)
        {
            if (b == self) continue;
            avg += b.Velocity;
            count++;
        }
        if (count == 0 || avg.sqrMagnitude < 0.0001f) return Vector3.zero;
        avg /= count;
        return avg.normalized * maxSpeed;
    }

    public static Vector3 Cohesion(BoidController self, List<BoidController> neighbors, float maxSpeed)
    {
        Vector3 center = Vector3.zero;
        int count = 0;
        foreach (var b in neighbors)
        {
            if (b == self) continue;
            center += b.Position;
            count++;
        }
        if (count == 0) return Vector3.zero;
        center /= count;
        return steering.Seek(self.Position, center, maxSpeed);
    }
}


