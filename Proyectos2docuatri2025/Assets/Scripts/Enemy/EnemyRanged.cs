using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RangedEnemy : Enemy
{
    [Header("Disparo")]
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float shootCooldown = 2f;
    private float shootTimer;
    public float shootSpeed;

    public GameObject deathParticlesPrefab;

    [Header("Distancia")]
    public float stopDistance = 8f;

    private Animator animator;
    public bool isCasting = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        shootTimer = shootCooldown; 
    }

    void Update()
    {
        if (player == null) return;

        RotateTowardsPlayer();

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            animator.SetBool("IsCasting", false);
            FollowPlayer();
        }
        else
        {
            animator.SetBool("IsCasting", true);

            shootTimer += Time.deltaTime;

            if (shootTimer >= shootCooldown)
            {
                ShootProjectile();
                shootTimer = 0f;
            }
        }
    }

    public void ShootProjectile()
    {
        if (player == null) return;

       
        animator.Play("Shoot", -1, 0f);

        
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = (player.position - shootPoint.position).normalized * shootSpeed;
    }

    void RotateTowardsPlayer()
    {
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(targetPosition);
    }

 

    protected override void Die()
    {
        if (deathParticlesPrefab != null)
        {
            Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

}
