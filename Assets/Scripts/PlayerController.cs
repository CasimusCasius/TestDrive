using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private DriveController driveController;
    private CarCheckpointController carCheckpointController;
    private Rigidbody rb;

    private float lastTimeMoving;
    [SerializeField] float respawnDelay = 4f;
    [SerializeField] int respawnLayerNumber = 6;
    [SerializeField] float layerResetTime = 3f;

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

        if (rb == null) { return; }

        if (rb.velocity.magnitude > 1 || !RaceController.isRacingStarted)
        {
            lastTimeMoving = Time.time;
        }

        if (Time.time > lastTimeMoving + respawnDelay)
        {
            RelocateCar();
        }

        if (!RaceController.isRacingStarted)
        {
            acceleration = 0;
            brake = 1;
        }

        driveController.Drive(acceleration, brake, steer);
    }

    private void RelocateCar()
    {
        GameObject lastCheckpoint = carCheckpointController.GetLastCheckpoint();
        rb.transform.position = lastCheckpoint.transform.position;

        rb.transform.rotation = //lastCheckpoint.transform.rotation; - oœ Z zgodna 
            Quaternion.LookRotation(lastCheckpoint.transform.right, Vector3.up);

        rb.gameObject.layer = respawnLayerNumber;

        Invoke(nameof(ResetLayer), layerResetTime);
    }

    private void ResetLayer()
    {
        rb.gameObject.layer = 0;
    }
}
