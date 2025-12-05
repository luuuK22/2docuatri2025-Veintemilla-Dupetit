using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipcosme : MonoBehaviour
{
    public string cosmeticID;

    public void Equip()
    {
        if (GameData.IsCosmeticOwned(cosmeticID))
        {
            GameData.EquippedCosmetic = cosmeticID;
            Debug.Log("Equipado: " + cosmeticID);
        }
        else
        {
            Debug.Log("Todavía no lo compraste.");
        }
    }
}
