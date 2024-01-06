using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarApperance : MonoBehaviour
{
    [SerializeField] private string playerName;
    [SerializeField] private Color carColor;
    [SerializeField] private TextMeshProUGUI textField;
    [SerializeField] private Renderer carModel;

    [SerializeField] private int playerNumber;
    
    private void Start()
    {
        if (playerNumber == 0)
        {
            playerName = PlayerPrefs.GetString(PlayerController.PLAYER_NAME_KEY);
            carColor = ColorCar.IntToColor
                (PlayerPrefs.GetInt(ColorCar.RED_KEY),
                PlayerPrefs.GetInt(ColorCar.GREEN_KEY),
                PlayerPrefs.GetInt(ColorCar.BLUE_KEY)
                );
        }
        else
        {
            playerName = "Random " + playerNumber;
            carColor = new Color(
                Random.Range(0f, 255f) / 255f,
                Random.Range(0f, 255f) / 255f,
                Random.Range(0f, 255f) / 255f
                );
        }



        textField.text = playerName;
        carModel.material.color = carColor;
        textField.color = carColor;
    }

    public void SetPlayerNumber(int playerNumber)
    {
        this.playerNumber = playerNumber;
    }

}
