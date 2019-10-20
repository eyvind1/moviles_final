using Photon.Realtime;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    public GameObject battleButton;
    public GameObject cancelButton;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        lobby = this;
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon master server");
        PhotonNetwork.AutomaticallySyncScene = true;
        battleButton.SetActive(true);
    }
    public void OnBattleButtonClicked()
    {
        Debug.Log("Battle button was clicked");
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("tried to join a random room but failed, there must be no open rooms available");
        CreateRoom();
    }
    void CreateRoom()
    {
        Debug.Log("Trying to create a new room");
        int randomRoomName = Random.Range(0,10000);
        RoomOptions roomOps = new RoomOptions() {IsVisible=true, IsOpen=true,MaxPlayers=(byte)MultiplayerSettings.multiplayerSettings.maxPlayers};
        PhotonNetwork.CreateRoom("Room"+ randomRoomName+roomOps);
    }
    
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("tried to join a random room but failed, there must already be a room with same name");
        CreateRoom();
    }
    public void OnCancelButtonClicked()
    {
        Debug.Log("Cancel button was clicked");
        cancelButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
