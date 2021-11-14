using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // OnLevelWasLoaded tadinda bir fonksiyon aramak.
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
