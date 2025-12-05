using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public IWeaponStrat strategy;

    [Header("Weapon Settings")]
    public float attackCooldown = 0.3f;

    private float cooldownTimer = 0f;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public void Attack(Enemy enemy)
    {
        if (cooldownTimer > 0f)
            return;

        int dmg = strategy.CalculateDamage(enemy.type);
        enemy.TakeDamage(dmg);

        EventManager.Trigger(EventType.OnEnemyHit);

        cooldownTimer = attackCooldown;
    }
}


