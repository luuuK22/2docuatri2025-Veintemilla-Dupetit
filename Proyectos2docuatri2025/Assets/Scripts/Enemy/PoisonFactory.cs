using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Factories/PoisonFactory")]

public class PoisonFactory : EnemyFactory
{
    [SerializeField] private Enemy prefab;

    public override Enemy CreateEnemy(Vector3 pos)
    {
        return Instantiate(prefab, pos, Quaternion.identity);
    }
}



