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
            audioPanel.SetActive(true);
        }
    }
    public void closePanel()
    {
        if (audioPanel != null)
        {
            audioPanel.SetActive(false);
        }

    }
}
