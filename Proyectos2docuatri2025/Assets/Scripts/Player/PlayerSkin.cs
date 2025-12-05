using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerSkin : MonoBehaviour
{
    [System.Serializable]
    public class SkinData
    {
        public string skinID;
        public Material[] materials;
    }

    [Header("Lista de skins disponibles")]
    public SkinData[] skins;

    private SkinnedMeshRenderer mesh;

    private void Awake()
    {
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();

        if (mesh == null)
        {
            Debug.LogError("ERROR: No se encontró SkinnedMeshRenderer en el Player.");
            return;
        }
    }

    private void Start()
    {
        // Si no hay skin equipada, asignar la default
        if (string.IsNullOrEmpty(GameData.EquippedSkin))
        {
            GameData.EquippedSkin = "Default";
        }

        ApplySkin();
    }

    public void ApplySkin()
    {
        if (mesh == null)
        {
            Debug.LogError("ApplySkin() falló: mesh es NULL");
            return;
        }

        string id = GameData.EquippedSkin;
        Debug.Log("Aplicando skin ID: " + id);

        foreach (var skin in skins)
        {
            if (skin.skinID == id)
            {
                mesh.materials = skin.materials;
                Debug.Log("Skin aplicada correctamente");
                return;
            }
        }

        Debug.LogWarning("No se encontró la skin con ID: " + id);
    }

}
