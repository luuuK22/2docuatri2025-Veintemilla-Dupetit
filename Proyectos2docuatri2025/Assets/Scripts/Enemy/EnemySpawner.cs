using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private EnemyFac factory;
    [SerializeField] private Camera cam;
    [SerializeField] private float spawnOffset = 2f; 

    public void SpawnEnemy(EnemyType type)
    {
        Vector3 spawnPos = GetOffscreenPosition();
        Enemy prefab = factory.GetEnemyPrefab(type);
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

    private Vector3 GetOffscreenPosition()
    {
        
        int side = Random.Range(0, 4);

        Vector3 pos = Vector3.zero;

       
        switch (side)
        {
            case 0: 
                pos = cam.ViewportToWorldPoint(new Vector3(0, Random.value, cam.nearClipPlane));
                pos.x -= spawnOffset;
                break;

            case 1:
                pos = cam.ViewportToWorldPoint(new Vector3(1, Random.value, cam.nearClipPlane));
                pos.x += spawnOffset;
                break;

            case 2: 
                pos = cam.ViewportToWorldPoint(new Vector3(Random.value, 1, cam.nearClipPlane));
                pos.y += spawnOffset;
                break;

            case 3: 
                pos = cam.ViewportToWorldPoint(new Vector3(Random.value, 0, cam.nearClipPlane));
                pos.y -= spawnOffset;
                break;
        }

        pos.z = 0; 

        return pos;
    }
}



