using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricStaffStrat : IWeaponStrat
{
    public int CalculateDamage(EnemyType type)
    {
        return DamageTable.table["ElectricStaff"][type];
    }
}
