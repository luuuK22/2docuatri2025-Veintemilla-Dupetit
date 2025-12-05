using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBuy : MonoBehaviour
{
    public string skinID;
    public int price;

    public void BuySkin()
    {
        if (GameData.Coins >= price)
        {
            GameData.Coins -= price;
            GameData.SetSkinOwned(skinID, true);
            Debug.Log("Compraste la skin: " + skinID);
        }
        else
        {
            Debug.Log("No tienes monedas suficientes.");
        }
    }
}
