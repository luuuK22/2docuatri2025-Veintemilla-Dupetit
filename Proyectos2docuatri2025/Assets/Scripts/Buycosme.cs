using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buycosme : MonoBehaviour
{
    public string cosmeticID;
    public int price;

    public void Buy()
    {
        if (GameData.Coins >= price)
        {
            GameData.Coins -= price;
            GameData.UnlockCosmetic(cosmeticID);
            Debug.Log("Compraste: " + cosmeticID);
        }
        else
        {
            Debug.Log("No tienes suficiente moneda.");
        }
    }
}
