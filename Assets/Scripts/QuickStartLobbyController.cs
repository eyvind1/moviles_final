﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject quickStartButton;
    [SerializeField]
    private GameObject quickCancelButton;
    [SerializeField]
    private int roomsize;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickStartButton.SetActive(true);
    }
    public void QuickStart()
    {
        quickStartButton.SetActive(false);
        quickCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("QuickStart");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("failed to create a room");
        
    }
    void CreateRoom()
    {
        Debug.Log("Create our room");
        int randomRoomNumber = Random.Range(0,10000);
        RoomOptions roomOps = new RoomOptions(){ IsVisible = true,IsOpen = true, MaxPlayers=(byte)roomsize};
        PhotonNetwork.CreateRoom("Room"+randomRoomNumber,roomOps);
        Debug.Log(randomRoomNumber);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Faide to create a room... try again");
        CreateRoom();
    }
    public void QuickCancel()
    {
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
