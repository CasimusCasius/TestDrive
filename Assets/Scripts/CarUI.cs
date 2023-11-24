using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarUI : MonoBehaviour
{
    [SerializeField] private string playerName;
    [SerializeField] Color playerColor;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Renderer carRenderer;
    [SerializeField] int playerNumber; // Serializacja do testów

    [SerializeField] private int playerNumber;

    void Start()
    {
        nameText.text = playerName;
        nameText.color = playerColor;
        carRenderer.material.color = playerColor ;   
    }

    public int GetPlayerNumber() => playerNumber;

    public void SetPlayerNumber(int number)
    { playerNumber = number; 
    }

}
