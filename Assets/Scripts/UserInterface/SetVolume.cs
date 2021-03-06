using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    public Slider sliderSFX;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        sliderSFX.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MasterBgm", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    public void SetSFX(float sliderValueSFX)
    {
        mixer.SetFloat("SFX", Mathf.Log10(sliderValueSFX) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderValueSFX);
    }
}
