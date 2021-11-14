using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Awake()
    {
        FindObjectOfType<AudioOptionsManager>().musicSet(PlayerPrefs.GetFloat("music volume"));
        FindObjectOfType<AudioOptionsManager>().effectSet(PlayerPrefs.GetFloat("effect volume"));
        AudioManager.instance.UpdateMixerVolume();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
