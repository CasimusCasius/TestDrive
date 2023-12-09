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
        textField.text = playerName;
        carModel.material.color = carColor;
        textField.color = carColor;
    }

    public void SetPlayerNumber(int playerNumber)
    {
        this.playerNumber = playerNumber;
    }

}
