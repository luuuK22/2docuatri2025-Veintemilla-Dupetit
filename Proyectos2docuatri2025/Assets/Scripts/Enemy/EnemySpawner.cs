using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Player Spawn Settings")]
    [SerializeField] private Transform player;
    [SerializeField] private float spawnMinDistance = 8f;
    [SerializeField] private float spawnMaxDistance = 12f;

    [Header("Factories")]
    [SerializeField] private EnemyFactory poisonFactory;
    [SerializeField] private EnemyFactory golemFactory;
    [SerializeField] private EnemyFactory robotFactory;

    [Header("Camera & Spawn Settings")]
    [SerializeField] private Camera cam;
    [SerializeField] private float spawnOffset = 2f;

    [Header("Survival Settings")]
    [SerializeField] private float baseSpawnRate = 2f; // 1 enemigo cada 2 sec
    [SerializeField] private int maxEnemies = 20;

    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            TrySpawn();
            spawnTimer = GetCurrentSpawnRate();
        }
    }

    private void TrySpawn()
    {
        if (CountEnemies() >= maxEnemies)
            return;

        EnemyType typeToSpawn = GetEnemyTypeByDifficulty();
        SpawnEnemy(typeToSpawn);
    }

    private float GetCurrentSpawnRate()
    {
        float t = Time.timeSinceLevelLoad;

        // Más tiempo = más enemigos por minuto
        if (t < 30) return baseSpawnRate;          // fácil
        if (t < 60) return baseSpawnRate * 0.8f;   // normal
        if (t < 120) return baseSpawnRate * 0.6f;  // difícil
        return baseSpawnRate * 0.45f;              // extremo
    }

    private int CountEnemies()
    {
        return FindObjectsOfType<Enemy>().Length;
    }

    private EnemyType GetEnemyTypeByDifficulty()
    {
        int r = Random.Range(0, 3); // 0, 1 o 2
        return (EnemyType)r;
    }

    public void SpawnEnemy(EnemyType type)
    {
        Vector3 pos = GetSpawnAroundPlayer();

        switch (type)
        {
            case EnemyType.PoisonSlime:
                poisonFactory.CreateEnemy(pos);
                break;

            case EnemyType.IceGolem:
                golemFactory.CreateEnemy(pos);
                break;

            case EnemyType.Robot:
                robotFactory.CreateEnemy(pos);
                break;
        }
    }

    private Vector3 GetSpawnAroundPlayer()
    {
        // Ángulo aleatorio 0..360°
        float angle = Random.Range(0f, Mathf.PI * 2f);

        // Distancia aleatoria entre mínimo y máximo
        float distance = Random.Range(spawnMinDistance, spawnMaxDistance);

        // Convertimos el ángulo en coordenadas XZ
        Vector3 offset = new Vector3(
            Mathf.Cos(angle),
            0,
            Mathf.Sin(angle)
        ) * distance;

        return player.position + offset;
    }

}



