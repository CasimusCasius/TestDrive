using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public static bool isRacingStarted = false;
    [SerializeField] private int timeToStart = 3;
    [SerializeField] private int totalLaps = 1;
    [SerializeField] TextMeshProUGUI startText;
    [SerializeField] private float startTextDisplayTime = 1f;
    // TODO DŸwiêk odliczania

    private CarCheckpointController[] carsCheckpoints;
    private const string carTag = "Car";

    private void Start()
    {
        //Debug.Log  ("------------------");
        HideStartText();
        InvokeRepeating(nameof(CountDown),3,1);

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
                Debug.Log("Race Finished");
                isRacingStarted = false;
            }
        }
    }

    private void CountDown()
    {
        startText.gameObject.SetActive(true);
        if (timeToStart != 0) 
        {
            startText.text = timeToStart.ToString();
            //Debug.Log("Rozpoczêcie wyœcigu za " + timeToStart);
            timeToStart--;

        }
        else
        {
            startText.text = "START";
            //Debug.Log("Start !!!");
            isRacingStarted = true;
            CancelInvoke(nameof(CountDown));
            Invoke(nameof(HideStartText),startTextDisplayTime);
        }
    }
    private void HideStartText()
    {
        startText.gameObject.SetActive(false);
    }
}
