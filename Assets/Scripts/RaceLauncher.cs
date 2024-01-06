using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceLauncher : MonoBehaviour
{
    [SerializeField] private InputField playerName;

    void Start()
    {
        if (PlayerPrefs.HasKey(PlayerController.PLAYER_NAME_KEY)) 
        { 
            playerName.text = PlayerPrefs.GetString(PlayerController.PLAYER_NAME_KEY);
        }
    }

    public void SetName(string name)
    {
        PlayerPrefs.SetString(PlayerController.PLAYER_NAME_KEY, name);
    }

    public void StartTrial()
    {
        SceneManager.LoadScene(1);
    }

}
