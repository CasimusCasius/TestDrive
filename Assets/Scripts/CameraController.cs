using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCam;
    [SerializeField] private Vector3[] cameraPositions;
    private int activePosition = 0;

    private void Start()
    {
        if (cameraPositions.Length < 1) return;

        SetCameraPosition(activePosition);

    }

    private void Update()
    {
        if (cameraPositions.Length < 1) return;

        if (Input.GetKeyDown(KeyCode.T))
        {
            activePosition++;
            activePosition = activePosition % cameraPositions.Length;
            SetCameraPosition(activePosition);
        }
    }

    private void SetCameraPosition(int cameraNumber)
    {
        vCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset =
            cameraPositions[cameraNumber];
    }


}
