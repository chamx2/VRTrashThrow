using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkConnectionManager : MonoBehaviourPunCallbacks
{

    public Button btnConnectMaster;
    public Button btnConnectRoom;

    public bool triesToConnectToMaster;
    public bool triesToConnectToRoom;


	// Use this for initialization
	void Start ()
    {
        triesToConnectToMaster = false;
        triesToConnectToRoom = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        btnConnectMaster.gameObject.SetActive(!PhotonNetwork.IsConnected && !triesToConnectToMaster);
        btnConnectRoom.gameObject.SetActive(PhotonNetwork.IsConnected && !triesToConnectToMaster && !triesToConnectToRoom);
		
	}

    public void OnClickConnectToMaster()
    {
        //Settings ( all optional and only for testing)

        PhotonNetwork.OfflineMode = false; // true would "fake" an online connection
        PhotonNetwork.NickName = "PlayerName"; // Set player name in the network
        PhotonNetwork.AutomaticallySyncScene = true; // to call PhotonNetwork.LoadLevel()
        PhotonNetwork.GameVersion = "v1"; // only people with the same game version can play together

        triesToConnectToMaster = true;
        //PhotonNetwork.ConnectToMaster(ip, port, appid); // manual connect
        PhotonNetwork.ConnectUsingSettings(); // automatic connection based on the config file in Photon/PhotonUnityNetworking/Resources/PhotonServerSettings
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        triesToConnectToMaster = false;
        triesToConnectToRoom = false;
        Debug.Log(cause);
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        triesToConnectToMaster = false;
        Debug.Log("Connected to Master!");
    }

    public void OnClickConnectToRoom()
    {
        if(!PhotonNetwork.IsConnected)
        {
            return;
        }

        triesToConnectToRoom = true;
        //PhotonNetwork.CreateRoom("Ace's Game 1"); // create a specific rtoom - Error: OnCreateRoomFailed
        //PhotonNetwork.JoinRoom("Ace's Game 1"); // join a specific Room Error:OnJoinRoomFailed
        PhotonNetwork.JoinRandomRoom(); // Join a random Room Error: OnJoinRandomRoomFailed
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        triesToConnectToRoom = false;
        Debug.Log("Master: " + PhotonNetwork.IsMasterClient + " | Players in Room: "+ PhotonNetwork.CurrentRoom.Name+ " Number of players: " + PhotonNetwork.CurrentRoom.PlayerCount);
        SceneManager.LoadScene("GameScene");

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        //no room available
        //create a room (null as name means "does not matter")
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 10});
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log(message);
        triesToConnectToRoom = false;
    }

    

}
