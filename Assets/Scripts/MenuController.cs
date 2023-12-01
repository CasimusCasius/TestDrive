using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{


    [SerializeField] Renderer carModel;
    [SerializeField] Slider redSlider, greenSlider, blueSlider;
    [SerializeField] TextMeshProUGUI redValue, greenValue, blueValue;
    [SerializeField] Color color;

    public const string RED_VALUE = "Red";
    public const string GREEN_VALUE = "Green";
    public const string BLUE_VALUE = "Blue";



    private void Start()
    {
        if (PlayerPrefs.HasKey(RED_VALUE) && PlayerPrefs.HasKey(GREEN_VALUE) &&
            PlayerPrefs.HasKey(BLUE_VALUE))
        {
            color = IntToColor(
                PlayerPrefs.GetInt(RED_VALUE),
                PlayerPrefs.GetInt(GREEN_VALUE),
                PlayerPrefs.GetInt(BLUE_VALUE));
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

        PlayerPrefs.SetInt(RED_VALUE, red);
        PlayerPrefs.SetInt(GREEN_VALUE, green);
        PlayerPrefs.SetInt(BLUE_VALUE, blue);

        
    }

}
