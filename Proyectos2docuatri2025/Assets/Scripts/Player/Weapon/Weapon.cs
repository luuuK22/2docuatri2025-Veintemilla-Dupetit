using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public IWeaponStrat strategy;

    public void Attack(Enemy enemy)
    {
        int dmg = strategy.CalculateDamage(enemy.type);
        enemy.TakeDamage(dmg);

        EventManager.Trigger(EventType.OnEnemyHit);
    }
}


