using UnityEngine;
using UnityEngine.SceneManagement;



public class Enemy : MonoBehaviour
{
    public EnemyType type;
    public int health = 30;

    public void TakeDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        EventManager.Trigger(EventType.OnEnemyDead);
        Destroy(gameObject);
    }
}



