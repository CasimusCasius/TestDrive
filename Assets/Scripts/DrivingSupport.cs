using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DriveSupport : MonoBehaviour
{
    private Rigidbody bodyCar;
    private float lastTimeChecked;
    [SerializeField] float antiRoll = 5000;
    [SerializeField] WheelScript[] frontWheels;
    [SerializeField] WheelScript[] rearWheels;

    private void Awake()
    {
        bodyCar = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.up.y > 0.5f || bodyCar.velocity.magnitude > 1)
            lastTimeChecked = Time.time;

        if (Time.time > lastTimeChecked + 3) TurnBackCar();
    }
    private void FixedUpdate()
    {
        HoldWheelOnGround(frontWheels);
        HoldWheelOnGround(rearWheels);
    }

    private void TurnBackCar()
    {
        transform.position += Vector3.up;

        transform.rotation = Quaternion.LookRotation(transform.forward);
    }

    private void HoldWheelOnGround(WheelScript[] wheels)
    {
        Dictionary<Side, float> suspention = new Dictionary<Side, float>();
        suspention.Clear();
        suspention = CreateSuspention(wheels);

        float antiRollForce = (suspention[Side.Left] - suspention[Side.Right]) * antiRoll;

        foreach (var wheel in wheels)
        {
            WheelCollider wheelCollider = wheel.GetWheelCollider();
            if (IsGrounded(wheelCollider, out WheelHit hit))
            {
                var force = wheelCollider.transform.up * antiRollForce;
                if (wheel.GetSide() == Side.Left)
                    force = -force;
                bodyCar.AddForceAtPosition(force, wheel.transform.position);
            }
        }
    }

    private Dictionary<Side, float> CreateSuspention(WheelScript[] wheels)
    {
        Dictionary<Side, float> suspentionForceFactor = new Dictionary<Side, float>();

        foreach (var wheel in wheels)
        {
            WheelCollider wheelCollider = wheel.GetWheelCollider();

            if (IsGrounded(wheelCollider, out WheelHit hit))
            {
                suspentionForceFactor[wheel.GetSide()] =
                    (-wheelCollider.transform.InverseTransformPoint(hit.point).y -
                    wheelCollider.radius) / wheelCollider.suspensionDistance;
            }
            else
                suspentionForceFactor[wheel.GetSide()] = 1.0f;
        }
        return suspentionForceFactor;
    }

    private bool IsGrounded(WheelCollider wheel, out WheelHit hit)
    {
        return wheel.GetGroundHit(out hit);
    }

}