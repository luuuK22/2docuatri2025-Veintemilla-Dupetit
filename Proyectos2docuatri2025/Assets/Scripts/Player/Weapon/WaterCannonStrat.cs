using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCannonStrat : IWeaponStrat
{
    public int CalculateDamage(EnemyType type)
    {
        return DamageTable.table["WaterCannon"][type];
    }
}
