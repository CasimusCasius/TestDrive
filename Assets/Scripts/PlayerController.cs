using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private DriveController driveController;
    private CarCheckpointController carCheckpointController;
    private Rigidbody rb;

    private float respawnDelay = 4;
    private float layerResetTime = 3;
    private float lastTimeMoving;
    [SerializeField] int respawnLayerNumber = 6;

    private void Awake()
    {
        driveController = GetComponent<DriveController>();
        carCheckpointController = GetComponent<CarCheckpointController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        float acceleration = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        float brake = Input.GetAxis("Jump");

        if(Input.GetKey(KeyCode.F4) && RaceController.isRacingStarted)
        {
            RelocateCar();
        }

        CheckCarMovement();

        if (!RaceController.isRacingStarted) 
        { 
            acceleration = 0;
            brake = 1;
        }

        driveController.Drive(acceleration, brake, steer);
    }

    private void CheckCarMovement()
    {
        if (rb == null) { return; }

        if (rb.velocity.magnitude>1 || !RaceController.isRacingStarted) 
        {
            lastTimeMoving = Time.time;
        }

        if (Time.time > lastTimeMoving + respawnDelay || rb.transform.position.y < -5)
        {
            RelocateCar();
        }
    }

    private void ResetLayer()
    {
        driveController.gameObject.layer = 0;
    }

    private void RelocateCar()
    {

        GameObject lastCheckpoint = carCheckpointController.GetLastCheckpoint();
        if (lastCheckpoint == null) { return; }
        rb.transform.position =
            lastCheckpoint.transform.position;
        
        rb.transform.rotation = 
            Quaternion.LookRotation(lastCheckpoint.transform.right,Vector3.up);

        rb.gameObject.layer = respawnLayerNumber;

        Invoke(nameof(ResetLayer), layerResetTime);
    }
}
