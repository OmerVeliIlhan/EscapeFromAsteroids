using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPanel : MonoBehaviour
{
    public GameObject audioPanel;
    public void openPanel()
    {
        if (audioPanel != null)
        {
            FindObjectOfType<AudioOptionsManager>().musicSliderSet(PlayerPrefs.GetFloat("music volume"));
            FindObjectOfType<AudioOptionsManager>().effectSliderSet(PlayerPrefs.GetFloat("effect volume"));
            audioPanel.SetActive(true);
        }
    }
    public void closePanel()
    {
        if (audioPanel != null)
        {
            audioPanel.SetActive(false);
            PlayerPrefs.Save();
        }

    }
}
