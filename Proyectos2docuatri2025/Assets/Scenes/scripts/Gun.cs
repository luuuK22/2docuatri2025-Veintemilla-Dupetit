using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    public Transform muzzle;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30f;
    public float cooldown = 0.6f;
    public float shootRange = 20f;
    float lastShot = -999f;
    HunterController owner;

    void Awake() { owner = GetComponentInParent<HunterController>(); }

    public void TryShootAt(BoidController boid)
    {
        if (Time.time - lastShot < cooldown) return;
        if (boid == null) return;

        // predicción simple: tiempo = distancia / bulletSpeed, usar la velocidad de boid
        Vector3 toTarget = boid.Position - muzzle.position;
        float dist = toTarget.magnitude;
        float t = dist / Mathf.Max(bulletSpeed, 0.001f);
        Vector3 aimPoint = boid.Position + boid.Velocity * t;

        Vector3 dir = (aimPoint - muzzle.position).normalized;
        GameObject b = Instantiate(bulletPrefab, muzzle.position, Quaternion.LookRotation(dir));
        Rigidbody rb = b.GetComponent<Rigidbody>();
        if (rb != null) rb.velocity = dir * bulletSpeed;
        lastShot = Time.time;
    }
}


