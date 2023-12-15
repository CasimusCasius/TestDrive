using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]private RaceController raceController;
    [SerializeField] TextMeshProUGUI startText;
    [SerializeField] private float startTextDisplayTime = 1f;
    [SerializeField] private GameObject finishScreen;
    [SerializeField] private TextMeshProUGUI waitText;
    [SerializeField] private Button startRace;


    private void Start()
    {
        raceController.onStartUpdate += UIUpdate;
        raceController.onTimerTick += Ticking;
        raceController.onRaceStart += ShowStartUI;
        raceController.onRaceFinish += ShowFinishUI;
        HideStartText();
    }

    private void UIUpdate(bool isMaster)
    {
        startRace.gameObject.SetActive(isMaster);
        waitText.gameObject.SetActive(!isMaster);
    }

    private void ShowFinishUI()
    {
        finishScreen.SetActive(true);
    }

    private void ShowStartUI()
    {
        startText.text = "START";
        Invoke(nameof(HideStartText),startTextDisplayTime);
    }

    private void Ticking(int timeToStart)
    {
        ShowHideStartText(true);
        startRace.gameObject.SetActive(false);
        waitText.gameObject.SetActive(false);
        startText.text = timeToStart.ToString();
    }

    private void ShowHideStartText(bool isActive)
    {
        startText.gameObject.SetActive(isActive);
    }
    private void HideStartText()
    {
        ShowHideStartText(false);
    }

   
}
