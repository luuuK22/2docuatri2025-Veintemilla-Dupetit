using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
   

    public static int Coins
    {
        get => PlayerPrefs.GetInt("Coins", 0);
        set => PlayerPrefs.SetInt("Coins", value);
    }

 
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

 
    public static float MasterVolume
    {
        get => PlayerPrefs.GetFloat("MasterVolume", 1f);
        set
        {
            PlayerPrefs.SetFloat("MasterVolume", value);
            AudioListener.volume = value;
        }
    }


    

    public static bool SkinFoxRed
    {
        get => PlayerPrefs.GetInt("SkinFoxRed", 0) == 1;
        set => PlayerPrefs.SetInt("SkinFoxRed", value ? 1 : 0);
    }

    public static bool ExtraDamageUpgrade
    {
        get => PlayerPrefs.GetInt("ExtraDamage", 0) == 1;
        set => PlayerPrefs.SetInt("ExtraDamage", value ? 1 : 0);
    }

    
    public static void ResetAll()
    {
        PlayerPrefs.DeleteAll();
    }
}


