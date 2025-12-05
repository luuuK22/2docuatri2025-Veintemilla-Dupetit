using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Factories/GolemFactory")]
public class GolemFactory : EnemyFactory
{

    [SerializeField] private Enemy prefab;

    public override Enemy CreateEnemy(Vector3 pos)
    {
        return Instantiate(prefab, pos, Quaternion.identity);
    }
}





