using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSlime : Enemy
{
    [SerializeField] private EnemyFactory factory;
    [SerializeField] private int miniHealth = 4;

    private bool isMiniSlime = false;

    // ----------------------
    // DAÑO AL PLAYER
    // ----------------------
    [SerializeField] private float damage = 5f;
    [SerializeField] private float attackCooldown = 1f;
    private float attackTimer = 0f;


    private void Update()
    {
        attackTimer -= Time.deltaTime;
    }


    private void OnTriggerStay(Collider other)
    {
        // solo atacar si pasó el cooldown
        if (attackTimer > 0)
            return;

        PlayerLife player = other.GetComponent<PlayerLife>();
        if (player != null)
        {
            player.TakeDamage(damage);
            attackTimer = attackCooldown;
        }
    }


    public override void Die()
    {
        if (!isMiniSlime)
            SpawnMiniSlimes();

        Destroy(gameObject);
    }

    private void SpawnMiniSlimes()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 offset = new Vector3(
                Random.Range(-0.6f, 0.6f),
                0,
                Random.Range(-0.6f, 0.6f)
            );

            Enemy e = factory.CreateEnemy(transform.position + offset);

            if (e == null)
            {
                Debug.LogError("PoisonFactory no devolvió un PoisonSlime.");
                return;
            }

            PoisonSlime mini = e as PoisonSlime;

            if (mini == null)
            {
                Debug.LogError("El prefab asignado a PoisonFactory NO es un PoisonSlime.");
                return;
            }

            mini.MakeMini();
        }
    }

    public void MakeMini()
    {
        isMiniSlime = true;
        health = miniHealth;
        transform.localScale *= 0.5f;
    }
}




