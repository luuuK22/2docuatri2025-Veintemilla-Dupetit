using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectPlayer : MonoBehaviour
{
    public float speed = 50f;
    private float damage = 1;
    private Vector3 direction;
  

    private Rigidbody rb;

   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetDamage(float dmg)
    {
        damage = dmg;
    }
    private void Start()
    {

      

        Destroy(gameObject, 5f);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;


        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
       
            if (other.CompareTag("Player")) return; // Ignorar al jugador

            IDamageable target = other.GetComponent<IDamageable>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
    }



    
}
