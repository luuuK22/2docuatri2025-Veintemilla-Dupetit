using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeLoader : MonoBehaviour
{
    [System.Serializable]
    public class CosmeticData
    {
        public string cosmeticID;
        public GameObject cosmeticObject;
    }

    public CosmeticData[] cosmetics;

    void Start()
    {
        LoadCosmetic();
    }

    public void LoadCosmetic()
    {
        foreach (var c in cosmetics)
            c.cosmeticObject.SetActive(false);

        string id = GameData.EquippedCosmetic;

        foreach (var c in cosmetics)
        {
            if (c.cosmeticID == id)
            {
                c.cosmeticObject.SetActive(true);
                break;
            }
        }
    }
}
