using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    public float lifeTime = 5f;
    public float damage = 100f;

    void Start() { Destroy(gameObject, lifeTime); }

    void OnCollisionEnter(Collision collision)
    {
       
        var boid = collision.collider.GetComponent<BoidController>();
        if (boid != null)
        {
            Destroy(boid.gameObject);
        }
        Destroy(gameObject);
    }
}

