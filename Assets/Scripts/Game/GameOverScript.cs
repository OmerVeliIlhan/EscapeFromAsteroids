using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    public Text pointsText;
    public Text pointsHighScoreText;
    public int currentScore;
    public void Start()
    {
        
        currentScore = ScoreCounter.scoreCounter.scoreValue;
        if (currentScore > ScoreCounter.scoreCounter.highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
        pointsText.text = "Score: " + currentScore.ToString();
        pointsHighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();

    }

    public void RestartButton()
    {
        ScoreCounter.scoreCounter.scoreValue = 0;
        SceneManager.LoadScene("Game");
       
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
