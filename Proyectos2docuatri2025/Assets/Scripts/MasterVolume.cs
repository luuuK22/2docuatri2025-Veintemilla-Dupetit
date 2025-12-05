using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        
        float saved = PlayerPrefs.GetFloat("MasterVolumeValue", 0.75f);
        slider.value = saved;

        
        SetVolume(saved);

        slider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;

        mixer.SetFloat("MasterVolume", dB);

        PlayerPrefs.SetFloat("MasterVolumeValue", value);
    }
}
