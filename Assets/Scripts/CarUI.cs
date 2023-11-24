using System;
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
        nameText.text = playerName;
        nameText.color = playerColor;
        carRenderer.material.color = playerColor ;   
    }

    public int GetPlayerNumber() => playerNumber;

    public void SetPlayerNumber(int number)
    { playerNumber = number; 
    }

}
