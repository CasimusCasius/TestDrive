using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorCar : MonoBehaviour
{
    public const string RED_KEY = "Red";
    public const string GREEN_KEY = "Green";
    public const string BLUE_KEY = "Blue";

    [SerializeField] private Renderer carModel;

    [SerializeField] private Slider redSlider;
    [SerializeField] private Slider greenSlider;
    [SerializeField] private Slider blueSlider;

    [SerializeField] private TextMeshProUGUI redText;
    [SerializeField] private TextMeshProUGUI greenText;
    [SerializeField] private TextMeshProUGUI blueText;

    [SerializeField] private Color color;


    void Start()
    {
        //if (!PlayerPrefs.HasKey(RED_KEY) || !PlayerPrefs.HasKey(GREEN_KEY)
        //    || !PlayerPrefs.HasKey(BLUE_KEY)) return;

        color = IntToColor(
            PlayerPrefs.GetInt(RED_KEY),
            PlayerPrefs.GetInt(GREEN_KEY),
            PlayerPrefs.GetInt(BLUE_KEY)
            );

        carModel.material.color = color;

        redSlider.value = color.r * 255f;
        greenSlider.value = color.g * 255f;
        blueSlider.value = color.b * 255f;
    }

    void Update()
    {
        SetCarColor((int)redSlider.value, (int)greenSlider.value, (int)blueSlider.value);

        redText.text = redSlider.value.ToString();
        greenText.text = greenSlider.value.ToString();
        blueText.text = blueSlider.value.ToString();

    }

    public static Color IntToColor(int red, int green, int blue)
    {
        float r = (float)red / 255;
        float g = (float)green / 255;
        float b = (float)blue / 255;

        Color newColor = new Color(r, g, b);
        return newColor;
    }

    private void SetCarColor(int red, int green, int blue)
    {
        carModel.material.color = IntToColor(red, green, blue);

        PlayerPrefs.SetInt(RED_KEY, red);
        PlayerPrefs.SetInt(GREEN_KEY, green);
        PlayerPrefs.SetInt(BLUE_KEY, blue);
    }
}
