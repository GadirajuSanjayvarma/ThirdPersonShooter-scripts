using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class roomLoad : MonoBehaviourPunCallbacks, IConnectionCallbacks
{
    string gameVersion = "1";
    public byte maxPlayers;
    // Start is called before the first frame update
    void Start()
    {
        connect();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void connect()
    {
        //Debug.Log(PhotonNetwork.NickName);
        // isConnectStatus=true;

        Debug.Log("inside connect method");
        // lobby.gameObject.SetActive(false);

        //level.gameObject.SetActive(true);
        if (PhotonNetwork.IsConnected)
        {

            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnDisconnected() was called by PUN with reason {0}", cause);

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("joining random failed");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayers });

    }

    public override void OnJoinedRoom()
    {

        //status.text = "connected";
        Debug.Log("joined a room");

        PhotonNetwork.LoadLevel("matchMakingScene");


    }


}
