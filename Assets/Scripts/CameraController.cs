using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera vCam;
    [SerializeField] Vector3[] camPosition;
    private int activeCamera = 0;

    private void Start()
    {
        if(camPosition.Length < 1 ) { return; }

        SetCameraPosition();
    }

    private void Update()
    {
        if (camPosition.Length < 2) { return; }

        if (Input.GetKeyDown(KeyCode.C)) 
        {
            activeCamera++;
            activeCamera = activeCamera % camPosition.Length;
            SetCameraPosition();
        }
    }

    private void SetCameraPosition()
    {
        vCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset =
            camPosition[activeCamera];
    }

    public void SetCameraProperties(DriveController car)
    {
        if (car == null) { return; }

        vCam.Follow = car.transform;
        vCam.LookAt = car.transform;
    }



}
