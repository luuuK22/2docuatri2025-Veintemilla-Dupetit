using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Referencia al script Weapon base")]
    [SerializeField] private Weapon weapon;

    [Header("Habilidades del zorro (scripts de poderes)")]
    [SerializeField] private FireSword fireSword;
    [SerializeField] private ElectricStaff electricStaff;
    [SerializeField] private WaterCannon waterCannon;

    private void Start()
    {
        // Por defecto podés iniciar con un arma
        EquipFireSword();
    }

    // -----------------------------------------------------
    //  Equipamientos
    // -----------------------------------------------------

    public void EquipFireSword()
    {
        weapon.strategy = new FireSwordStrat();
        EnableWeapon("Sword");
        Debug.Log("Equipped Fire Sword");
    }

    public void EquipElectricStaff()
    {
        weapon.strategy = new ElectricStaffStrat();
        EnableWeapon("Electric");
        Debug.Log("Equipped Electric Staff");
    }

    public void EquipWaterCannon()
    {
        weapon.strategy = new WaterCannonStrat();
        EnableWeapon("Water");
        Debug.Log("Equipped Water Cannon");
    }

    // -----------------------------------------------------
    //  Activar / Desactivar poderes
    // -----------------------------------------------------
    private void EnableWeapon(string type)
    {
        fireSword.enabled = (type == "Sword");
        electricStaff.enabled = (type == "Electric");
        waterCannon.enabled = (type == "Water");
    }
}
