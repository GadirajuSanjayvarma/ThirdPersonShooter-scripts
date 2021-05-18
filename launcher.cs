using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class launcher : MonoBehaviourPunCallbacks
{
    string gameVersion = "1";
    // Start is called before the first frame update
    private byte maxPlayersPerRoom = 4;
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            // PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            Debug.Log("hi");
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void OnConnectedToMaster()
    {
        Debug.Log("conncetd to master0");
        //PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        Debug.Log("creating a room");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("i am in a room");
    }


    public void takeMeToNextLevel()
    {
        StartCoroutine(disablefade());
    }



    private IEnumerator disablefade()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("testScene");

    }



}
