using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSash : MonoBehaviour
{
    public Weapon weapon;         
    public float speed = 10f;      
    public float lifeTime = 0.4f;   

    private Vector3 direction;

    void Start()
    {
      
        direction = transform.forward;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy e = other.GetComponent<Enemy>();
        if (e != null)
        {
            weapon.Attack(e); // aplica daño usando tu strategy pattern
        }
    }
}
