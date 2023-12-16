using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    [SerializeField] private float rotatationSpeed = 10f;


    void Update()
    {
        transform.Rotate(0,rotatationSpeed * Time.deltaTime ,0);
    }
}
