using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{

    // ---- Currency ----
    public static int Coins
    {
        get => PlayerPrefs.GetInt("Coins", 0);
        set => PlayerPrefs.SetInt("Coins", value);



    }

    public static bool IsCosmeticOwned(string cosmeticID)
    {
        return PlayerPrefs.GetInt("Cosmetic_" + cosmeticID, 0) == 1;
    }

    public static void UnlockCosmetic(string cosmeticID)
    {
        PlayerPrefs.SetInt("Cosmetic_" + cosmeticID, 1);
    }

    public static string EquippedCosmetic
    {
        get => PlayerPrefs.GetString("EquippedCosmetic", "None");
        set => PlayerPrefs.SetString("EquippedCosmetic", value);
    }
    public static bool IsSkinOwned(string skinID)
    {
        return PlayerPrefs.GetInt("SkinOwned_" + skinID, 0) == 1;
    }

    public static void SetSkinOwned(string skinID, bool owned)
    {
        PlayerPrefs.SetInt("SkinOwned_" + skinID, owned ? 1 : 0);
    }

   
    public static string EquippedSkin
    {
        get => PlayerPrefs.GetString("EquippedSkin", "Default");
        set => PlayerPrefs.SetString("EquippedSkin", value);
    }

    // ---- Stamina ----
    public static int MaxStamina => 5;

    public static int CurrentStamina
    {
        get => PlayerPrefs.GetInt("Stamina", 5);
        set => PlayerPrefs.SetInt("Stamina", Mathf.Clamp(value, 0, MaxStamina));
    }

    public static string LastStaminaTimeKey => "LastStaminaTime";

    public static void UseStamina()
    {
        if (CurrentStamina <= 0) return;

        CurrentStamina--;
        PlayerPrefs.SetString(LastStaminaTimeKey, System.DateTime.Now.ToString());
    }

    public static void RegenerateStamina(int minutesPerPoint = 10)
    {
        if (!PlayerPrefs.HasKey(LastStaminaTimeKey)) return;

        var last = System.DateTime.Parse(PlayerPrefs.GetString(LastStaminaTimeKey));
        var diff = System.DateTime.Now - last;

        int recovered = (int)(diff.TotalMinutes / minutesPerPoint);
        if (recovered <= 0) return;

        CurrentStamina = Mathf.Min(MaxStamina, CurrentStamina + recovered);
        PlayerPrefs.SetString(LastStaminaTimeKey, System.DateTime.Now.ToString());
    }

    // ---- Audio ----
    public static float MasterVolume
    {
        get => PlayerPrefs.GetFloat("MasterVolume", 1f);
        set
        {
            PlayerPrefs.SetFloat("MasterVolume", value);
            AudioListener.volume = value;
        }
    }

    // ---- Reset ----
    public static void ResetAll()
    {
        PlayerPrefs.DeleteAll();
    }
}


