using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    [SerializeField] private int checkpointCount;

    private const string CHECKPOINT_TAG = "Checkpoint";
    private int nextCheckpoint;
    private int lapCounter = 0;

    private void Start()
    {
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag(CHECKPOINT_TAG);
        checkpointCount = checkpoints.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == CHECKPOINT_TAG)
        {
            int thisCheckpoint = int.Parse(other.gameObject.name);
            if (thisCheckpoint == nextCheckpoint)
            {
                if (thisCheckpoint == 0)
                {
                    lapCounter++;
                    Debug.Log("Lap: " + lapCounter);
                }
                nextCheckpoint++;
                nextCheckpoint %= checkpointCount;

            }
        }
    }

    public int GetLap() => lapCounter;
    //{
    //    return lapCounter;
    //}

}