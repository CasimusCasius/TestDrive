using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceController : MonoBehaviour
{
    public Action<int> onTimerTick;
    public Action onRaceStart;
    public Action onRaceFinish;

    public static bool isRacingStarted = false;
    [SerializeField] private int timeToStart = 3;
    [SerializeField] private int totalLaps = 1;
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private int playersCount = 1; // serialize tylko do testów
    // TODO DŸwiêk odliczania

    private CarCheckpointController[] carsCheckpoints;
    private const string carTag = "Car";

    private void Start()
    {
        //Debug.Log  ("------------------");
        
        InvokeRepeating(nameof(CountDown),3,1);
    

        for (int i = 0; i < playersCount; i++)
        {
            GameObject car = Instantiate(carPrefab, spawnPositions[i].position,
                spawnPositions[i].rotation);
            car.GetComponent<CarUI>().SetPlayerNumber(i);
            if(i == 0)
            {
                car.GetComponent<PlayerController>().enabled = true;
                GameObject.FindObjectOfType<CameraController>().
                    SetCameraProperties(car.GetComponent<DriveController>());
            }
            else
            {
                car.GetComponent<PlayerController>().enabled = false;
            }

        }


        GameObject[] cars = GameObject.FindGameObjectsWithTag(carTag);
        carsCheckpoints = new CarCheckpointController[cars.Length];
        for (int i = 0; i < cars.Length; i++)
        {
            carsCheckpoints[i] = cars[i].GetComponent<CarCheckpointController>();
        }
    }

    private void LateUpdate()
    {
        int finishedLap = 0;
        foreach (var carCheckpoint in carsCheckpoints)
        {
            if (carCheckpoint.GetLap() == totalLaps + 1) finishedLap++;

            if (finishedLap == carsCheckpoints.Length && isRacingStarted) 
            {
                //Debug.Log("Race Finished");
                onRaceFinish?.Invoke();
                isRacingStarted = false;
            }
        }
    }

    public void RestartRace()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

    private void CountDown()
    {
       
        if (timeToStart != 0) 
        {
            onTimerTick?.Invoke(timeToStart);
            timeToStart--;
        }
        else
        {
            isRacingStarted = true;
            onRaceStart?.Invoke();
            CancelInvoke(nameof(CountDown));
        }
    }
    
}
