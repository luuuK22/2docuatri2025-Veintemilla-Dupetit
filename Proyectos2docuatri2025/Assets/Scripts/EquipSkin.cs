using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSkin : MonoBehaviour
{
    public string skinID;

    public void Equip()
    {
        if (GameData.IsSkinOwned(skinID))
        {
            GameData.EquippedSkin = skinID;
            Debug.Log("Skin equipada: " + skinID);
        }
        else
        {
            Debug.Log("Todavía no la compraste.");
        }
    }
}
