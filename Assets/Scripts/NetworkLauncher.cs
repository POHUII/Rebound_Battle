using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    public GameObject loginUI;
    public GameObject nameUI;
    public InputField roomName;
    public InputField playerName;
    public GameObject titleUI;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        print("Welcome Connect!");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        titleUI.SetActive(true);
        nameUI.SetActive(true);

        //µÇÂ½ÓÎÏ·´óÌü
        PhotonNetwork.JoinLobby();
    }

    public void PlayButton()
    {
        nameUI.SetActive(false);

        PhotonNetwork.NickName = playerName.text;
        loginUI.SetActive(true);
    }

    public void JoinOrCreate()
    {
        if (roomName.text.Length < 2)
            return;

        loginUI.SetActive(false);

        RoomOptions options = new RoomOptions { MaxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel(1);
        print("Welcome!"+PhotonNetwork.NickName);
    }
}
