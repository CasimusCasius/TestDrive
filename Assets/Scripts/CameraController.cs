using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3[] cameraPosition;
    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private KeyCode changeCameraKey = KeyCode.C;
    private int activePosition = 0;

    void Start()
    {
        if (cameraPosition.Length == 0)
            return;
        ChangeCameraPosition();
    }

    void Update()
    {
        if (cameraPosition.Length == 0)
            return;
        
        if (Input.GetKeyDown(changeCameraKey))
        {
            activePosition++;
            activePosition %= cameraPosition.Length;

            ChangeCameraPosition();
        }
    }

    public void SetCameraProperties(Transform car)
    {
        vcam.Follow = car;
        vcam.LookAt = car;
    }


    private void ChangeCameraPosition()
    {
        vcam.GetCinemachineComponent<CinemachineFramingTransposer>().
                    m_TrackedObjectOffset = cameraPosition[activePosition];
    }
}
