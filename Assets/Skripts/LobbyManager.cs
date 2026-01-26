using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Collections.Generic;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Image i1;
    public Image i2;

    private int availableRooms = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        PhotonNetwork.NickName = "Player: " + Random.Range(1, 457);
        Debug.Log(PhotonNetwork.NickName);

        PhotonNetwork.GameVersion = "1.0";
        PhotonNetwork.ConnectUsingSettings();
    }  

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
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
       if(PhotonNetwork.IsConnectedAndReady) 
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
