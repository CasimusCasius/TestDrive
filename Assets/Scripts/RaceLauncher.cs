using Photon.Realtime;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceLauncher : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField playerName;
    [SerializeField] private TextMeshProUGUI networkText;
    public const string PLAYER_NAME_KEY = "PlayerName";

    private byte maxPlayerPerRoom = 3;
    private bool isConnecting;
    private const string GAME_VERSION = "2.0";

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        if (PlayerPrefs.HasKey(PLAYER_NAME_KEY))
        {
            playerName.text = PlayerPrefs.GetString(PLAYER_NAME_KEY);
        }
    }

    public void SetPlayerName(string playerName)
    {
        PlayerPrefs.SetString(PLAYER_NAME_KEY, playerName);
    }

    public void StartTrial()
    {
        SceneManager.LoadScene(1);
    }

    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            networkText.text += "On Connect to master ... \n";
            PhotonNetwork.JoinRandomRoom();
        }

    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        networkText.text += "Failed to join Random Room! \n";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayerPerRoom });
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        networkText.text += "Disconnected because " + cause + "\n";
        isConnecting = false;
    }

    public override void OnJoinedRoom()
    {
        networkText.text = "Joined room with " + PhotonNetwork.CurrentRoom.PlayerCount +
            "players.\n";
        PhotonNetwork.LoadLevel(1);
    }

    public void ConnectNetwork()
    {
        networkText.text = "";
        isConnecting = true;
        PhotonNetwork.NickName = playerName.text;

        if (PhotonNetwork.IsConnected)
        {
            networkText.text += "Joining room ... \n";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            networkText.text += "Connecting ... \n";
            PhotonNetwork.GameVersion = GAME_VERSION;
            PhotonNetwork.ConnectUsingSettings();

        }
    }

}
