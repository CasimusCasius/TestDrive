using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;


public class RaceController : MonoBehaviourPunCallbacks
{
    public event Action<bool> onStartUpdate;
    public event Action<int> onTimerTick;
    public event Action onRaceStart;
    public event Action onRaceFinish;

    public static bool isRacingStarted = false;
    [SerializeField] private int timeToStart = 3;
    [SerializeField] private int totalLaps = 1;
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private int playersCount = 1; // serialize tylko do testów


    // TODO DŸwiêk odliczania

    private CarCheckpointController[] carsCheckpoints;
    private const string carTag = "Car";

    private void Start()
    {
        playersCount = PhotonNetwork.CurrentRoom.PlayerCount;

        int randomStartPosition = UnityEngine.Random.Range(0, playersCount);
        Vector3 startPos = spawnPositions[randomStartPosition].position;
        Quaternion startRot = spawnPositions[randomStartPosition].rotation;

        GameObject playerCar = null;

        if (PhotonNetwork.IsConnected)
        {
            startPos = spawnPositions[PhotonNetwork.CurrentRoom.PlayerCount - 1].position;
            startRot = spawnPositions[PhotonNetwork.CurrentRoom.PlayerCount - 1].rotation;

            if (OnlinePlayer.LocalPlayerInstance == null)
            {
                playerCar = PhotonNetwork.Instantiate(carPrefab.name, startPos, startRot);
            }

            onStartUpdate?.Invoke(PhotonNetwork.IsMasterClient);

            playerCar.GetComponent<DriveController>().enabled = true;
            playerCar.GetComponent<PlayerController>().enabled = true;
        }


    }
    private void LateUpdate()
    {
        int finishedLap = 0;
        foreach (var carCheckpoint in carsCheckpoints)
        {
            if (carCheckpoint.GetLap() == totalLaps + 1) finishedLap++;

            if (finishedLap == carsCheckpoints.Length && isRacingStarted)
            {
                //Debug.Log("Race Finished");
                onRaceFinish?.Invoke();
                isRacingStarted = false;
            }
        }
    }
    public void RestartRace()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

    [PunRPC]
    public void StartGame()
    {
        InvokeRepeating(nameof(CountDown), 3, 1);

        

        GameObject[] cars = GameObject.FindGameObjectsWithTag(carTag);
        carsCheckpoints = new CarCheckpointController[cars.Length];
        for (int i = 0; i < cars.Length; i++)
        {
            carsCheckpoints[i] = cars[i].GetComponent<CarCheckpointController>();
        }
    }

    public void BeginGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC(nameof(StartGame), RpcTarget.All, null);
        }
    }

    private void CountDown()
    {

        if (timeToStart != 0)
        {
            onTimerTick?.Invoke(timeToStart);
            timeToStart--;
        }
        else
        {
            isRacingStarted = true;
            onRaceStart?.Invoke();
            CancelInvoke(nameof(CountDown));
        }
       
    }

}
