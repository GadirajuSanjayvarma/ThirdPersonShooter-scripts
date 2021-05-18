using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

using Photon.Realtime;

public class matchMaking : MonoBehaviour
{
    public GameObject[] playersArray;
    byte currentPlayers;
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = PhotonView.Get(this);
        currentPlayers = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount != currentPlayers)
        {
            //this.GetComponent<AudioSource>().Play();
            //Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
            currentPlayers = PhotonNetwork.CurrentRoom.PlayerCount;
            for (int i = 0; i < playersArray.Length; i++)
            {
                playersArray[i].gameObject.SetActive(false);

            }


            for (int i = 0; i < currentPlayers; i++)
            {
                playersArray[i].gameObject.SetActive(true);

            }
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {

                StartCoroutine(loadLevel(5.0f));

            }

        }


    }

    private IEnumerator loadLevel(float time)
    {
        yield return new WaitForSeconds(time);
        PhotonNetwork.LoadLevel("testScene");


    }


}
