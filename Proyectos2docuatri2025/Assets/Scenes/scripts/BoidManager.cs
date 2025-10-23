
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    
    [Header("Collections")]
    public List<BoidController> boids = new List<BoidController>();
    public List<GameObject> foods = new List<GameObject>();
    public HunterController hunter;

    [Header("Wander")]
    public float wanderRadius = 20f;

    void Update()
    {
        
        for (int i = foods.Count - 1; i >= 0; i--)
        {
            GameObject f = foods[i];
            if (f == null) { foods.RemoveAt(i); continue; }
            foreach (var b in boids)
            {
                if (b == null) continue;
                float d = Vector3.Distance(b.Position, f.transform.position);
                if (d <= b.arriveRadius * 0.6f)
                {
                    Destroy(f);
                    foods.RemoveAt(i);
                    break;
                }
            }
        }
    }

    public List<BoidController> GetNeighbors(BoidController self, float radius)
    {
        List<BoidController> result = new List<BoidController>();
        float r2 = radius * radius;
        foreach (var b in boids)
        {
            if (b == null) continue;
            if ((b.Position - self.Position).sqrMagnitude <= r2) result.Add(b);
        }
        return result;
    }

    public GameObject GetClosestFood(Vector3 pos, float radius)
    {
        GameObject closest = null;
        float minSqr = radius * radius;
        foreach (var f in foods)
        {
            if (f == null) continue;
            float sq = (f.transform.position - pos).sqrMagnitude;
            if (sq <= minSqr)
            {
                if (closest == null || sq < (closest.transform.position - pos).sqrMagnitude)
                    closest = f;
            }
        }
        return closest;
    }

    public HunterController GetHunterInView(Vector3 pos, float radius)
    {
        if (hunter == null) return null;
        float d2 = (hunter.transform.position - pos).sqrMagnitude;
        if (d2 <= radius * radius)
            return hunter;
        return null;
    }

    public Vector3 GetRandomWanderVelocity(Vector3 pos, float maxSpeed)
    {
        Vector3 randPoint = pos + Random.insideUnitSphere * 3f;
        randPoint.y = pos.y;
        return steering.Seek(pos, randPoint, maxSpeed);
    }

#if UNITY_EDITOR
 
    public void RegisterBoid(BoidController b) { if (!boids.Contains(b)) boids.Add(b); }
    public void RegisterFood(GameObject f) { if (!foods.Contains(f)) foods.Add(f); }
#endif
}


