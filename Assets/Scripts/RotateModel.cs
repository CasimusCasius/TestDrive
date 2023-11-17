using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{

    [SerializeField] float speed = 50f;

    
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
