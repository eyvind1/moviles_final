using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSetup : MonoBehaviour
{
    public static GameSetup GS;
    public int nextPlayersTeam;
    public Text  healthDisplay;
    //public Transform[] spawnPoints;
    public Transform[] spawnPointsTeamOne;
    public Transform[] spawnPointsTeamTwo;
    public Transform[] spawnPointsTeamThree;
    public Transform[] spawnPointsTeamFour;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        if(GameSetup.GS==null)
        {
            GameSetup.GS=this;
        }
    }

    public void DisconnectPlayer()
    {
        StartCoroutine(DisconnectAndLoad());
    }

    IEnumerator DisconnectAndLoad()
    {
        PhotonNetwork.Disconnect();
        while(PhotonNetwork.IsConnected)
        {
            yield return null;
        }
        SceneManager.LoadScene(MultiplayerSettings.multiplayerSettings.menuScene);
    }
    public void UpdateTeam()
    {
        if(nextPlayersTeam == 1)
        {
            nextPlayersTeam= 2;
        }
        else if(nextPlayersTeam == 2)
        {
            nextPlayersTeam = 3;
        }
        else if(nextPlayersTeam == 3)
        {
            nextPlayersTeam = 4;
        }
    }

}
