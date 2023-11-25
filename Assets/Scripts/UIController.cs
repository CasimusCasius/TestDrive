using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private RaceController raceController;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private float startTextDisplayTime;

    private void OnEnable()
    {
        raceController.onTimeTick += Ticking;
        raceController.onRaceStart += UpdateOnRaceStart;
    }

    private void OnDisable()
    {
        raceController.onTimeTick -= Ticking;
        raceController.onRaceStart -= UpdateOnRaceStart;
    }
    private void UpdateOnRaceStart()
    {
        infoText.text = "START!";
        Invoke(nameof(HideStartText), startTextDisplayTime);

    }
    private void Ticking(int time)
    {
        infoText.text = time.ToString();
    }

    private void ShowHideStartText(bool show)
    {
        infoText.gameObject.SetActive(show);
    }

    private void HideStartText()
    {
        ShowHideStartText(false);
    }

}
