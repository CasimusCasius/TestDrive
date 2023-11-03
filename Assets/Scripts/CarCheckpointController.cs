using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCheckpointController : MonoBehaviour
{
    private int lap = 0;
    private int checkpoint = -1;
    private int nextCheckpoint = 0;
    private int checkpointCount;

    private const string CHECKPOINT_TAG = "Checkpoint";

    private void Start()
    {
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag(CHECKPOINT_TAG);
        checkpointCount = checkpoints.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == CHECKPOINT_TAG)
        {
            int thisCheckpoint = int.Parse(other.name);
            if (thisCheckpoint == nextCheckpoint)
            {
                checkpoint = thisCheckpoint;
                if (thisCheckpoint == 0)
                {
                    lap++;
                    Debug.Log("Lap number" +  lap);
                }

                nextCheckpoint++;
                nextCheckpoint %= checkpointCount;

                Debug.Log("Next checkpoint :" +  nextCheckpoint);
            }

        }
    }
    public int GetLap() => lap;
}
