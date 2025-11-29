using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Factories/PoisonFactory")]

public class PoisonFactory : EnemyFac
{
    public Enemy prefab;

    public  Enemy CreateEnemy(Vector3 pos)
    {
        return Instantiate(prefab, pos, Quaternion.identity);
    }
}


