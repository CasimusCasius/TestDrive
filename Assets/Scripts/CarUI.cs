
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarUI : MonoBehaviour
{
    [SerializeField] private string playerName;
    [SerializeField] private Color playerColor;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Renderer carRenderer;
    [SerializeField] private int playerNumber; // Serializacja do testów

    

    void Start()
    {
        if (playerNumber == 0)
        {
            playerName = PlayerPrefs.GetString(RaceLauncher.PLAYER_NAME_KEY);
            playerColor = MenuController.IntToColor(
                PlayerPrefs.GetInt(MenuController.RED_VALUE),
                PlayerPrefs.GetInt(MenuController.GREEN_VALUE),
                PlayerPrefs.GetInt(MenuController.BLUE_VALUE)
                );
        }
        else
        {
            playerName = "Random" + playerNumber;
            playerColor = new Color(
                Random.Range(0f,1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f));
        }

        nameText.text = playerName;
        nameText.color = playerColor;
        carRenderer.material.color = playerColor ;   
    }

    public int GetPlayerNumber() => playerNumber;

    public void SetPlayerNumber(int number)
    { playerNumber = number; 
    }

}
