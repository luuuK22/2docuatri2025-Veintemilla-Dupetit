using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManag : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public Transform player;           
    public float spawnRadius = 10f;     
    public float spawnInterval = 2f;   

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        
        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPos = player.position + new Vector3(randomCircle.x, 0, randomCircle.y);
        GameObject enemyPrefab = Random.value < 0.5f ? enemyPrefab1 : enemyPrefab2;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}


