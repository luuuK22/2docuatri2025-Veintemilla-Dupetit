using UnityEngine;



public abstract class Enemy : MonoBehaviour , IDamageable
{
    public float life;
    public float speed;
    [SerializeField] public Transform player;


    public delegate void EnemyDamaged(float currentLife);
    public event EnemyDamaged OnEnemyDamaged;


    public delegate void EnemyDied();
    public event EnemyDied OnEnemyDied;

    public void TakeDamage(float dmg)
    {
        life -= dmg;


        OnEnemyDamaged?.Invoke(life);

        if (life <= 0)
        {
            Die();
            

            OnEnemyDied?.Invoke();
        }
    }

    protected virtual void FollowPlayer()
    {
        if (player == null) player = GameObject.FindWithTag("Player").transform;
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    protected abstract void Die();
}