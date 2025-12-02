using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSwordStrat : IWeaponStrat
{
    public int CalculateDamage(EnemyType type)
    {
        return DamageTable.table["FireSword"][type];
    }
}
