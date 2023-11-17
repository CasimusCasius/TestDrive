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

    [SerializeField] private int playerNumber;

    public void SetPlayerNumber(int i)
    {
        playerNumber = i;
    }

    void Start()
    {
        nameText.text = playerName;
        nameText.color = playerColor;
        carRenderer.material.color = playerColor ;
        
    }

}
