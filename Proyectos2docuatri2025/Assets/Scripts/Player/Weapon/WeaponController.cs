using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon weapon;

    public void EquipWaterCannon()
    {
        weapon.strategy = new WaterCannonStrat();
    }

    public void EquipFireSword()
    {
        weapon.strategy = new FireSwordStrat();
    }

    public void EquipBlowgun()
    {
        weapon.strategy = new ElectricStaffStrat();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
        }
    }

    void ShootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Enemy e = hit.collider.GetComponent<Enemy>();
            if (e != null)
            {
                weapon.Attack(e);
            }
        }
    }
}
