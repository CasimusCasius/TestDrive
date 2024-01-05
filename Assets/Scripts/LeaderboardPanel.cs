using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class LeaderboardPanel : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> placesNumbers;

    void Start()
    {
        LeaderBoard.Reset();
    }

    private void LateUpdate()
    {
        List<string> places = LeaderBoard.GetPlaces();

        for (int i = 0; i < placesNumbers.Count; i++)
        {
            if (i < places.Count) 
            {
                placesNumbers[i].text = places[i];
            }
            else
            {
                placesNumbers[i].text = "";
            }
        }

    }


}
