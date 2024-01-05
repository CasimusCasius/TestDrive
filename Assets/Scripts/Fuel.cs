using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField]private float AMOUNT_OF_ROTATION = 0.4f;
    private Collider collider;
    private Renderer renderer;
    private Color myColor;
    private Color grey = new Color(0.5f, 0.5f, 0.5f);

    private void Awake()
    {
        collider = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();
    }

    void Start()
    {
        collider.enabled = true;
        myColor = renderer.material.color;
    }

    void Update()
    {
        float rotationSpeed =AMOUNT_OF_ROTATION * Time.deltaTime;
        transform.Rotate(new Vector3(rotationSpeed, -rotationSpeed, rotationSpeed));
    }

    public IEnumerator UseFuel()
    {
        collider.enabled = false;
        renderer.material.color = grey;
        renderer.material.SetColor("_EmissionColor", grey);

        yield return new WaitForSeconds(10);

        collider.enabled = true;
        renderer.material.color = myColor;
        renderer.material.SetColor("_EmissionColor", myColor);
    }

    private void OnTriggerEnter(Collider other)
    {
        // sprawdü kto wywo≥al trigger
        // dodaj paliwo do istniejπcego

        StartCoroutine(UseFuel());
    }


}
