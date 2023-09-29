using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{

    [SerializeField] private WheelCollider wheelCollider;
    [SerializeField] private GameObject wheelModel;
    [SerializeField] private bool isFrontWheel; 

    public WheelCollider GetWheelCollider() => wheelCollider; 
    public GameObject GetWheelModel() => wheelModel;
    public bool IsFrontWheel() => isFrontWheel;
}
