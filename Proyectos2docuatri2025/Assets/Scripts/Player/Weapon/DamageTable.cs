using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageTable 
{
    public static readonly Dictionary<string, Dictionary<EnemyType, int>> table =
        new Dictionary<string, Dictionary<EnemyType, int>>
    {
        {
            "WaterCannon",
            new Dictionary<EnemyType, int>
            {
                { EnemyType.Robot, 20 },
                { EnemyType.IceGolem, 5 },
                { EnemyType.PoisonSlime, 5 }
            }
        },
        {
            "FireSword",
            new Dictionary<EnemyType, int>
            {
                { EnemyType.IceGolem, 20 },
                { EnemyType.Robot, 5 },
                { EnemyType.PoisonSlime, 5 }
            }
        },
        {
            "ElectricStaff",
            new Dictionary<EnemyType, int>
            {
                { EnemyType.PoisonSlime, 20 },
                { EnemyType.Robot, 5 },
                { EnemyType.IceGolem, 5 }
            }
        }
    };
}
