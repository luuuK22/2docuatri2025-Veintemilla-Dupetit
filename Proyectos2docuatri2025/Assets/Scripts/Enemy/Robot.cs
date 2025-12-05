using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Enemy
{
    [Header("Factory")]
    [SerializeField] private EnemyFactory factory;

    [Header("Damage to Player")]
    [SerializeField] private float damage = 8f;
    [SerializeField] private float attackCooldown = 1f;
    private float attackTimer = 0f;

    private void Update()
    {
        attackTimer -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (attackTimer > 0) return;

        PlayerLife player = other.GetComponent<PlayerLife>();
        if (player != null)
        {
            player.TakeDamage(damage);
            attackTimer = attackCooldown;
        }
    }

    public override void Die()
    {
        // Si queres que el robot explote o tire chispas, este es el lugar.
        Destroy(gameObject);
    }
}
