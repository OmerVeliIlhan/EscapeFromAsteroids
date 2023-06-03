using UnityEngine;
using UnityEngine.UI;
using StackExchange.Redis;

public class PlayerNameHandler : MonoBehaviour
{
    public InputField playerNameInput;
    private IDatabase db;

    private void Start()
    {
        db = RedisConnector.Connection;
    }


    public void SavePlayerName()
    {
        string playerName = playerNameInput.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            // "playerName" keyini kullanarak oyuncunun ismini PlayerPrefs'a kaydedin
            PlayerPrefs.SetString("playerName", playerName);
        }
        else
        {
            Debug.Log("Player name cannot be empty");
        }
    }

}
