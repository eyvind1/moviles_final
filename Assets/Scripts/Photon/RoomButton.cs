using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomButton : MonoBehaviour
{
    public Text nameText;
    public Text sizeText;
    public string roomName;
    public int roomSize;
    //public InputField roomName2;
    public void SetRoom()
    {
        nameText.text = roomName;
        //nameText.text = roomName2.text;
        sizeText.text = roomSize.ToString();
    }

    public void JoinRoomOnClick()
    {
        PhotonNetwork.JoinRoom(roomName);
    }
}
