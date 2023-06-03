using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StackExchange.Redis;

public class GameOverScript : MonoBehaviour
{
    public GameObject scoreEntryPrefab;
    public Transform scoreEntryParent;
    private IDatabase db;

    void Start()
    {
        db = RedisConnector.Connection;  // Burası doğru
        ShowScores();
    }

    private void ShowScores()
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        var scores = db.SortedSetRangeByRankWithScores("scores", order: Order.Descending);
        foreach(var score in scores)
        {
            if(scoreEntryPrefab && scoreEntryParent)
            {
                GameObject entry = Instantiate(scoreEntryPrefab, scoreEntryParent);
                entry.transform.Find("PlayerName").GetComponent<Text>().text = score.Element.ToString();
                entry.transform.Find("Score").GetComponent<Text>().text = score.Score.ToString();
                if (score.Element == playerName)
                {
                    entry.transform.Find("PlayerName").GetComponent<Text>().color = Color.green;
                    entry.transform.Find("Score").GetComponent<Text>().color = Color.green;
                }
            }
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
