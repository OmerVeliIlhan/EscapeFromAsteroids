using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StackExchange.Redis;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter scoreCounter;
    public GameOverScript gameOverScript;
    public int scoreValue = 0;
    public int highScore;
    public int makeitHarder;
    Text score;
    
    private IDatabase db;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        scoreCounter = this;
        score = GetComponent<Text>();
        makeitHarder = scoreValue + 200;
        
        db = RedisConnector.Connection;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;

        Debug.Log("Health: " + HealthHandler.instance.health);


        if(HealthHandler.instance.health == 0)
        {
            
            Debug.Log("Game over should be triggered now.");

            GameOver();
        }
        if(makeitHarder == scoreValue && FindObjectOfType<DeployBullet>().respawnTime > 0.6f)
        {
            FindObjectOfType<DeployBullet>().respawnTime -= 0.1f;
            makeitHarder = scoreValue + 200;
        }
    }

public void GameOver()
{
    string playerName = PlayerPrefs.GetString("playerName");
        
    if (!string.IsNullOrEmpty(playerName))
    {
        db.StringSet(playerName, scoreValue);
    }
    
    try
    {
        SceneManager.LoadScene("GameOver");
    }
    catch (System.Exception e)
    {
        Debug.Log("Failed to load GameOver scene: " + e.Message);
    }
}

}
