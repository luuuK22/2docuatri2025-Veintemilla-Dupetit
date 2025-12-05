using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public EnemyType type;
    public int health = 10;

    public virtual void TakeDamage(int dmg)
    {
        health -= dmg;

        HitFlash(); 

        if (health <= 0)
            Die();
    }

    public virtual void Die()
    {
        
        EventManager.Trigger(EventType.OnEnemyDead);

        
        Destroy(gameObject);
    }

    private void HitFlash()
    {
        StartCoroutine(DamageFlashRoutine());
    }

    private IEnumerator DamageFlashRoutine()
    {
        Renderer rend = GetComponentInChildren<Renderer>();

        if (rend == null)
            yield break;

        Color original = rend.material.color;
        rend.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        rend.material.color = original;
    }
}





