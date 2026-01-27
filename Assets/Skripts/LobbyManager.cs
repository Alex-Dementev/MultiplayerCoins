using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Collections.Generic;
using System.Collections;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Image i1;
    public Image i2;

    private int availableRooms = 0;

    private bool Sec5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        PhotonNetwork.NickName = "Player: " + Random.Range(1, 457);
        Debug.Log(PhotonNetwork.NickName);

        PhotonNetwork.GameVersion = "1.0";
        PhotonNetwork.ConnectUsingSettings();

        StartCoroutine(DelayFiveSeconds());
    }  

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    IEnumerator DelayFiveSeconds()
    {
        yield return new WaitForSeconds(5f);
        Sec5 = true;
    }

    public override void OnRoomListUpdate(List<Photon.Realtime.RoomInfo> roomList)
    {
        availableRooms  = 0;

        foreach (var room in roomList)
        {
            // Учитываем только открытые и неполные комнаты
            if (room.IsOpen && room.IsVisible && room.PlayerCount < room.MaxPlayers)
            {
                availableRooms++;
            }
        }
    }     

    void Update()
    {
       if(PhotonNetwork.IsConnectedAndReady && Sec5) 
       {
            i1.color = new Color(0, 109/255f, 241/255f);

            if(availableRooms >= 1)
            i2.color = new Color(0, 109/255f, 241/255f);
       }
       else
       {
            i1.color = new Color(149/255f, 149/255f, 149/255f);
            i2.color = new Color(149/255f, 149/255f, 149/255f);
       }
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions {MaxPlayers = 8});
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }
}
