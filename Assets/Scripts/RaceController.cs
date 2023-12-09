using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceController : MonoBehaviour
{
    public Action<int> onTimeTick;
    public Action onRaceStart;
    public Action onRaceFinish;

    public static bool isRacing = false;

    [SerializeField] private int playerCount; // Serializacja do testów

    [Header("Start Properties")]
    [SerializeField] private int timeToStart = 3;
    [SerializeField] private int totalLaps = 1;

    [Header("Car Properties")]
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private const string CAR_TAG = "Car";
    private CheckpointController[] carsController;

    private void Start()
    {
        float startDelay = 3f;

        // Debug.Log("------------------");
        InvokeRepeating(nameof(CountDown), startDelay, 1);

        for (int i = 0; i < playerCount; i++)
        {
            var car = Instantiate(carPrefab);
            car.transform.position = spawnPoints[i].transform.position;
            car.transform.rotation = spawnPoints[i].transform.rotation;

            car.GetComponent<CarApperance>().SetPlayerNumber(i);

            if (i == 0)
            {
                car.GetComponent<PlayerController>().enabled = true;
                GameObject.FindObjectOfType<CameraController>().
                    SetCameraProperties(car.transform);
            }

        }

        GameObject[] cars = GameObject.FindGameObjectsWithTag(CAR_TAG);
        carsController = new CheckpointController[cars.Length];
        for (int i = 0; i < cars.Length; i++)
        {
            carsController[i] = cars[i].GetComponent<CheckpointController>();
        }
    }

    private void LateUpdate()
    {
        int howManyCarsFinishedRace = 0;

        foreach (var controller in carsController)
        {
            if (controller.GetLap() == totalLaps + 1)
            {
                howManyCarsFinishedRace++;   
            }
            if (howManyCarsFinishedRace == carsController.Length && isRacing)
            {
                Debug.Log("Finish Race!!");
                onRaceFinish.Invoke();
                isRacing = false;
            }
        }
    }
    
    private void CountDown()
    {
        if (timeToStart != 0)
        {
            Debug.Log("Rozpoczêcie wyœcigu za: " + timeToStart);
            onTimeTick.Invoke(timeToStart);
            timeToStart--;
        }
        else
        {
            Debug.Log("Start!!!");
            onRaceStart.Invoke();
            isRacing = true;
            CancelInvoke(nameof(CountDown));
        }
    }

    public void RestartLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

}
