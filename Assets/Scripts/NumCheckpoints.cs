using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class NumCheckpoints : MonoBehaviour
{
    [SerializeField] private Transform[] checkpoint;

    private void Start()
    {
        checkpoint = GetComponentsInChildren<Transform>();

        for (int i = 1; i < checkpoint.Length ; i++)
        {
            checkpoint[i].gameObject.name = (i-1).ToString();
        }
    }
}
