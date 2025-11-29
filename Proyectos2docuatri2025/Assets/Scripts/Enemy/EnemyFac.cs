using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFac : MonoBehaviour
{

    [SerializeField] private Enemy zombiePrefab;
    [SerializeField] private Enemy golemPrefab;
    [SerializeField] private Enemy robotPrefab;

    public Enemy GetEnemyPrefab(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.PoisonSlime: return zombiePrefab;
            case EnemyType.IceGolem: return golemPrefab;
            case EnemyType.Robot: return robotPrefab;
            default:
                Debug.LogError("EnemyType no encontrado: " + type);
                return null;
        }
    }

    // ✔️ Este es el método que querías agregar
    public Enemy CreateEnemy(EnemyType type, Vector3 position)
    {
        Enemy prefab = GetEnemyPrefab(type);
        if (prefab == null)
        {
            Debug.LogError("Prefab no asignado para " + type);
            return null;
        }

        return Instantiate(prefab, position, Quaternion.identity);
    }
}


