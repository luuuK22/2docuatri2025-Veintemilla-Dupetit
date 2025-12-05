using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonSound : MonoBehaviour
{
    public AudioSource uiAudioSource;   
    public AudioClip clickSound;

    void Awake()
    {
        
        Button[] buttons = FindObjectsOfType<Button>(true);

        foreach (Button b in buttons)
        {
            b.onClick.AddListener(PlayClickSound);
        }
    }

    public void PlayClickSound()
    {
        if (uiAudioSource != null && clickSound != null)
            uiAudioSource.PlayOneShot(clickSound);
    }
}
