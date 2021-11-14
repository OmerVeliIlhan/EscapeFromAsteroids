using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOptionsManager : MonoBehaviour
{
    public static float musicVolume { get; set; }
    public static float soundEffectVolume { get; set; }


    public void OnMusicSliderValue(float value)
    {
        musicVolume = value;
        AudioManager.instance.UpdateMixerVolume();
        PlayerPrefs.SetFloat("music volume", musicVolume);
    }
    public void OnEffectSliderValue(float value)
    {
        soundEffectVolume = value;
        AudioManager.instance.UpdateMixerVolume();
        PlayerPrefs.SetFloat("effect volume", soundEffectVolume);
    }


    public void musicSet(float value)
    {
        musicVolume = value;
    }

    public void effectSet(float value)
    {
        soundEffectVolume = value;
    }
}
