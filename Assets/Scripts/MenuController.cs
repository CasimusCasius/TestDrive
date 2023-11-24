using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{


    [SerializeField] Renderer carModel;
    [SerializeField] Slider redSlider, greenSlider, blueSlider;
    [SerializeField] TextMeshProUGUI redValue, greenValue, blueValue;
    [SerializeField] Color color;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Red") && PlayerPrefs.HasKey("Green") &&
            PlayerPrefs.HasKey("Blue"))
        {
            color = IntToColor(
                PlayerPrefs.GetInt("Red"),
                PlayerPrefs.GetInt("Green"),
                PlayerPrefs.GetInt("Blue"));
        }

        carModel.material.color = color;

        redSlider.value = (int)(color.r * 255f);
        greenSlider.value = (int)(color.g * 255f);
        blueSlider.value = (int)(color.b * 255f);
    }

    private void Update()
    {
        SetCarColor((int)redSlider.value, (int)greenSlider.value, (int)blueSlider.value);

        redValue.text = redSlider.value.ToString();
        greenValue.text = greenSlider.value.ToString();
        blueValue.text = blueSlider.value.ToString();

    }

    public static Color IntToColor(int red, int green, int blue)
    {
        float r = (float)red / 255;
        float g = (float)green / 255;
        float b = (float)blue / 255;

        return new Color(r, g, b);
    }

    private void SetCarColor(int red, int green, int blue)
    {
        Color carColor = IntToColor(red, green, blue);
        carModel.material.color = carColor;

        PlayerPrefs.SetInt("Red", red);
        PlayerPrefs.SetInt("Green", green);
        PlayerPrefs.SetInt("Blue", blue);

        
    }

}
