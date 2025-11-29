using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Factories/GolemFactory")]
public class GolemFactory : EnemyFac
{
 
    public Enemy prefab;

    public  Enemy CreateEnemy(Vector3 pos)
    {
        return Instantiate(prefab, pos, Quaternion.identity);
    }
}

