using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RaceLauncher : MonoBehaviour
{
    [SerializeField]private TMP_InputField playerName;

    public const string PLAYER_NAME_KEY = "PlayerName";

    void Start()
    {
        if (PlayerPrefs.HasKey(PLAYER_NAME_KEY))
        {
            playerName.text = PlayerPrefs.GetString(PLAYER_NAME_KEY);
        }
    }

   public void SetPlayerName(string playerName)
    {
        PlayerPrefs.SetString(PLAYER_NAME_KEY, playerName);
    }

    public void StartTrial()
    {
        SceneManager.LoadScene(0);
    }
}
