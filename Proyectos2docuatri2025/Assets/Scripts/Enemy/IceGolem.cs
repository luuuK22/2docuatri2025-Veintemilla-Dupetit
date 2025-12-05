using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGolem : Enemy
{
    [Header("AOE Attack Settings")]
    [SerializeField] private float attackRadius = 2.5f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float slowDuration = 2f;
    [SerializeField] private float attackCooldown = 4f;

    [Header("Factory")]
    [SerializeField] private EnemyFactory factory;

    private float cooldownTimer = 0f;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
    }

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (player == null) return;

        float dist = Vector3.Distance(transform.position, player.position);

       
        if (dist <= attackRadius && cooldownTimer <= 0f)
        {
            DoAOEAttack();
            cooldownTimer = attackCooldown;
        }
    }

    private void DoAOEAttack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, attackRadius);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                
                var dmg = hit.GetComponent<IDamageable>();
                dmg?.TakeDamage(damage);

                
                var slow = hit.GetComponent<PlayerSlow>();
                if (slow != null)
                {
                    slow.ApplySlow(slowDuration);
                }
            }
        }

        Debug.Log("Golem realizó un ataque AOE");
    }

    public override void Die()
    {
        base.Die();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
