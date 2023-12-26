using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlinePlayer : MonoBehaviourPunCallbacks
{
    public static GameObject LocalPlayerInstance;

    // Start is called before the first frame update
    void Awake()
    {
        if (photonView.IsMine)
        {
            LocalPlayerInstance = gameObject;
        }
        else
        {
            string playerName = null;
            Color playerColor = Color.white;

            if (photonView.InstantiationData != null)
            {
                playerName = (string)photonView.InstantiationData[0];
                playerColor =
                    MenuController.IntToColor((int)photonView.InstantiationData[1],
                    (int)photonView.InstantiationData[2],
                    (int)photonView.InstantiationData[3]);

                if (playerName != null)
                {
                    GetComponent<CarUI>().SetNameAndColor(playerName, playerColor);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
