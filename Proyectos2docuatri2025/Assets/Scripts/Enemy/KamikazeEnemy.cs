using UnityEngine;

public class KamikazeEnemy : Enemy
{
    public float explosionRadius = 3f;
    public float explosionDamage = 50f;
    private bool hasExploded = false;
    public GameObject deathParticlesPrefab;
    void Update()
    {
        FollowPlayer();
        if (Vector3.Distance(transform.position, player.position) < 1.5f)
        {
            Explode();
        }

        RotateTowardsPlayer();
    }



    void RotateTowardsPlayer()
    {
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(targetPosition);
    }
    void Explode()
    {
        if (hasExploded)
            return;
        hasExploded = true;

        if (deathParticlesPrefab != null)
        {
            Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);
        }


        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in hitColliders)
        {
            IDamageable target = col.GetComponent<IDamageable>();
            if (target != null)
                target.TakeDamage(30);
        }
        Destroy(gameObject);
    }
    protected override void Die()
    {

        Explode();
    }
}