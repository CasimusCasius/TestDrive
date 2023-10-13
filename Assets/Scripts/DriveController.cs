using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveController : MonoBehaviour
{
    [Header("Car properties") ]
    [SerializeField] private WheelScript[] wheels;
    [SerializeField] private float torque = 200;
    [SerializeField] private float maxSteerAngle = 30;
    [SerializeField] private float maxBrakeTorque = 500;
    [SerializeField] private float maxSpeed = 200;

    [Header("only for orientation")]
    [Tooltip("this velocity is not in km/h")]
    [SerializeField] float currentSpeed;

    private Vector3 lastPosition;
    private float velocityScale = 10f;


    private void Start()
    {
        lastPosition = transform.position;
    }

    public void Drive(float acceleration, float brake, float steer)
    {
        acceleration = Mathf.Clamp(acceleration, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
        brake = Mathf.Clamp01(brake) * maxBrakeTorque;

        float thrustTorque = 0;

        if (currentSpeed < maxSpeed)
        {
            thrustTorque = acceleration * torque;
        }

        foreach (var wheel in wheels)
        {
            wheel.GetWheelCollider().motorTorque = thrustTorque;

            if (wheel.IsFrontWheel())
            {
                wheel.GetWheelCollider().steerAngle = steer;
            }
            else
            {
                wheel.GetWheelCollider().brakeTorque = brake;
            }

            Quaternion quat;
            Vector3 position;

            wheel.GetWheelCollider().GetWorldPose(out position, out quat);
            
            wheel.GetWheelModel().transform.position = position;
            wheel.GetWheelModel().transform.rotation = quat;

        }
    }

    private void FixedUpdate()
    {
        currentSpeed = Vector3.Distance(
            Vector3.ProjectOnPlane(transform.position,Vector3.up),
            Vector3.ProjectOnPlane(lastPosition, Vector3.up)) / Time.fixedDeltaTime * velocityScale;

        lastPosition = transform.position;
    }
}
