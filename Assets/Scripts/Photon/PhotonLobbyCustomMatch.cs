using Photon.Realtime;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonLobbyCustomMatch : MonoBehaviourPunCallbacks, ILobbyCallbacks
{
    public static PhotonLobbyCustomMatch lobby;
    public string roomName;
    public int roomSize;
    public GameObject roomListingPrefab; 
    public Transform roomsPanel;
    //public InputField  roomNameInputField;
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
        PhotonNetwork.NickName = "Player "+Random.Range(0,1000);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        RemoveRoomListings();
        foreach(RoomInfo room in roomList)
        {
            ListRoom(room);
        }
    }

    void RemoveRoomListings()
    {
        while (roomsPanel.childCount!=0)
        {
            Destroy(roomsPanel.GetChild(0).gameObject);
        }
    }

    void ListRoom(RoomInfo room)
    {
        if (room.IsOpen && room.IsVisible)
        {
            GameObject tempListing = Instantiate(roomListingPrefab,roomsPanel);
            RoomButton tempButton = tempListing.GetComponent<RoomButton>();
            tempButton.roomName = room.Name;
            tempButton.roomSize = room.MaxPlayers;
            tempButton.SetRoom();
        }
    }
    

    public void CreateRoom()
    {
        Debug.Log("Trying to create a new room");
        RoomOptions roomOps = new RoomOptions() {IsVisible=true, IsOpen=true,MaxPlayers=(byte)roomSize};
        PhotonNetwork.CreateRoom(roomName,roomOps);
    }
    
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("tried to join a random room but failed, there must already be a room with same name");
        //CreateRoom();
    }

    public void OnRoomNameChanged(string nameIn)
    {
        roomName = nameIn;
        //roomName = roomNameInputField.text;
    }
    
    public void OnRoomSizeChanged(int sizeIn)
    {
        roomSize = sizeIn;
    }

    public void JoinLobbyOnClick()
    {
        if(!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }
}
