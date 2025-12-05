using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFactory : ScriptableObject
{
    public abstract Enemy CreateEnemy(Vector3 pos);
}
