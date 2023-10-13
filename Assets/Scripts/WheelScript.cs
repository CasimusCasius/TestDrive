using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side {  Left, Right };

public class WheelScript : MonoBehaviour
{
    [SerializeField] private WheelCollider wheelCollider;
    [SerializeField] private GameObject wheelModel;
    [SerializeField] private bool isFrontWheel; 
    [SerializeField] private Side side;
    

    public WheelCollider GetWheelCollider() => wheelCollider; 
    public GameObject GetWheelModel() => wheelModel;
    public bool IsFrontWheel() => isFrontWheel;
    public Side GetSide() => side;
}
