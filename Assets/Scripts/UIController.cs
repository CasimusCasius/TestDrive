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
    [SerializeField] private GameObject endRacePanel;

    private void Start()
    {
        endRacePanel.SetActive(false);
    }
    private void OnEnable()
    {
        raceController.onTimeTick += Ticking;
        raceController.onRaceStart += UpdateOnRaceStart;
        raceController.onRaceFinish += RaceFinished;
    }

    private void OnDisable()
    {
        raceController.onTimeTick -= Ticking;
        raceController.onRaceStart -= UpdateOnRaceStart;
        raceController.onRaceFinish -= RaceFinished;
    }

    private void RaceFinished()
    {
        endRacePanel.SetActive(true);
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
