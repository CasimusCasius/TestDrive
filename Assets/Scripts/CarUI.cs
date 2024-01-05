
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

    private int carRego;
    private bool regoSet = false;
    private CarCheckpointController carCheckpointController;


    void Start()
    {
        carCheckpointController = GetComponent<CarCheckpointController>();
    }

    private void LateUpdate()
    {
        if (!regoSet)
        {
            carRego = LeaderBoard.RegisterCar(playerName);
            regoSet = true;
            return;
        }
        LeaderBoard.SetPosition(carRego, carCheckpointController.GetLap(),
            carCheckpointController.GetCheckpoint());
    }
    public int GetPlayerNumber() => playerNumber;

    public void SetPlayerNumber(int number)
    { 
        playerNumber = number;
    }

    public void SetNameAndColor(string name, Color color)
    {
        playerName = name;
        playerColor = color;
        nameText.color = color;
    }

    public void SetLocalPlayer()
    {
        FindObjectOfType<CameraController>().SetCameraProperties(this.transform);
        playerName = PlayerPrefs.GetString (RaceLauncher.PLAYER_NAME_KEY);
        playerColor = MenuController.IntToColor(
                PlayerPrefs.GetInt(MenuController.RED_VALUE),
                PlayerPrefs.GetInt(MenuController.GREEN_VALUE),
                PlayerPrefs.GetInt(MenuController.BLUE_VALUE)
                );
        nameText.text = playerName;
        carRenderer.material.color = playerColor;
        nameText.color = playerColor;
    }
    
}
