using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCheckpointController : MonoBehaviour
{
    private int lap = 0;
    private int checkpoint = -1;
    private GameObject lastCheckpoint;
    private int nextCheckpoint = 0;
    private int checkpointCount;

    private const string CHECKPOINT_TAG = "Checkpoint";

    private void Start()
    {
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag(CHECKPOINT_TAG);
        checkpointCount = checkpoints.Length;
        for (int i = 0; i < checkpointCount; i++)
        {
            if (checkpoints[i].name == "0")
            {
                lastCheckpoint = checkpoints[i];
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == CHECKPOINT_TAG)
        {
            int thisCheckpoint = int.Parse(other.name);
            if (thisCheckpoint == nextCheckpoint)
            {
                lastCheckpoint = other.gameObject;
                checkpoint = thisCheckpoint;
                if (thisCheckpoint == 0)
                {
                    lap++;
                }

                nextCheckpoint++;
                nextCheckpoint %= checkpointCount;
            }
        }
    }
    public int GetLap() => lap;

    public GameObject GetLastCheckpoint() => lastCheckpoint;
}
