using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const string PLAYER_NAME_KEY = "PlayerName";
    private const int deathHightValue = -5;
    private const int invincibleTime = 3;
    [SerializeField] float maxNotMovingTime = 2f;
    private DriveController driveController;
    private CheckpointController checkpointController;
    private float lastTimeMoving = 0;
    private Rigidbody rb;

    private void Awake()
    {
        driveController = GetComponent<DriveController>();
        checkpointController = GetComponent<CheckpointController>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float acceleration = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        float brake = Input.GetAxis("Jump");

        StuckCheck();

        if (!RaceController.isRacing)
        {
            acceleration = 0f;
            brake = 1f;
        }

        driveController.Drive(acceleration, brake, steer);
    }

    private void StuckCheck()
    {
        if (rb.velocity.magnitude > 1 || !RaceController.isRacing)
        {
            lastTimeMoving = Time.time;
        }

        if (Time.time > lastTimeMoving + maxNotMovingTime ||
            gameObject.transform.position.y < deathHightValue)
        {
            transform.position =
                checkpointController.GetLastCheckpoint().transform.position;
            transform.rotation =
                checkpointController.GetLastCheckpoint().transform.rotation;

            gameObject.layer = 6;
            Invoke(nameof(ResetLayer), invincibleTime);
        }
    }

    private void ResetLayer()
    {
        gameObject.layer = 0;
    }

}
