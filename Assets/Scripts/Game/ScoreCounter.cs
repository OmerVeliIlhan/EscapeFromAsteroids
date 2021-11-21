using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreCounter : MonoBehaviour
{
    
    public static ScoreCounter scoreCounter;
    public GameOverScript gameOverScript;
    public int scoreValue = 0;
    public int highScore;
    public int makeitHarder;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        scoreCounter = this;
        score = GetComponent<Text>();
        makeitHarder = scoreValue + 600;
    }

    // Update is called once per frame
    void Update()
    {

        score.text = "Score: " + scoreValue;
        if(HealthHandler.instance.health == 0)
        {
            GameOver();
        }
        if(makeitHarder == scoreValue && FindObjectOfType<DeployBullet>().respawnTime > 0.6f)
        {
            FindObjectOfType<DeployBullet>().respawnTime -= 0.1f;
            makeitHarder = scoreValue + 600;
        }

    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
