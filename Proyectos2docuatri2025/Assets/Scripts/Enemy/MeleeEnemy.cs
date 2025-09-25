using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float stopDistance = 1.5f;
    public float attackCooldown = 1.5f;
    private float attackTimer = 0f;

    private Animator animator;
    public GameObject deathParticlesPrefab;
    [Header("Referencia a trigger de ataque")]
    public Collider attackTrigger;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (attackTrigger != null)
            attackTrigger.enabled = false; // Desactivamos el trigger al inicio
    }

    void Update()
    {
        if (player == null)
            return;

        RotateTowardsPlayer();

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            FollowPlayer();
            DisableAttackTrigger();
        }
        else
        {
            if (attackTimer <= 0f)
            {
                Attack();
                attackTimer = attackCooldown;
            }
        }

        if (attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    void RotateTowardsPlayer()
    {
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(targetPosition);
    }

    void Attack()
    {
        //animator.SetTrigger("Attack");
        EnableAttackTrigger();

        // Desactivar el trigger después de un breve delay para simular el golpe
        Invoke(nameof(DisableAttackTrigger), 0.3f); // ajusta el tiempo según la animación
    }

    void EnableAttackTrigger()
    {
        if (attackTrigger != null)
            attackTrigger.enabled = true;
    }

    void DisableAttackTrigger()
    {
        if (attackTrigger != null)
            attackTrigger.enabled = false;
    }

    protected override void Die()
    {

        if (deathParticlesPrefab != null)
        {
            Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);
        }
        DisableAttackTrigger();
        Destroy(gameObject);
    }
}
