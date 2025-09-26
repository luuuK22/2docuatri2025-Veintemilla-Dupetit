using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 20f;
    public float lifetime = 15f;

    void Start()
    {

        Destroy(gameObject, lifetime);
    }


    void OnTriggerEnter(Collider other)
    {

        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }


        Destroy(gameObject);
    }
}
