using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBolt : MonoBehaviour
{
    public Weapon weapon;
    public Vector3 direction;
    public float speed = 20f;
    public float lifeTime = 1.2f;
    public float impactRadius = 1f;
    public AudioSource shock;
    private void Start()
    {
        shock.Play();
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy e = other.GetComponent<Enemy>();
        if (e != null)
        {
            weapon.Attack(e);
            Destroy(gameObject);
        }
    }
}
