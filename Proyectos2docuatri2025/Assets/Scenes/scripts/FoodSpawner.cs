using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public Vector3 spawnAreaCenter = Vector3.zero;
    public Vector3 spawnAreaSize = new Vector3(40f, 0f, 40f);
    public float spawnInterval = 6f;
    public int maxFood = 10;
    BoidManager manager;

    void Start()
    {
        manager = FindObjectOfType<BoidManager>();
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (manager == null || foodPrefab == null) continue;
        
            if (manager.foods.Count >= maxFood) continue;
            Vector3 pos = spawnAreaCenter + new Vector3(
                Random.Range(-spawnAreaSize.x * 0.5f, spawnAreaSize.x * 0.5f),
                0f,
                Random.Range(-spawnAreaSize.z * 0.5f, spawnAreaSize.z * 0.5f)
            );
            GameObject f = Instantiate(foodPrefab, pos, Quaternion.identity);
            manager.foods.Add(f);
        }
    }
}


