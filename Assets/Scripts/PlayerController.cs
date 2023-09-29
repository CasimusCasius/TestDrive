using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private DriveController driveController;

    private void Awake()
    {
        driveController = GetComponent<DriveController>();
    }


    void Update()
    {
        float acceleration = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        float brake = Input.GetAxis("Jump");


        driveController.Drive(acceleration, brake, steer);

       
    }
}
