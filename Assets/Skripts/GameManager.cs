using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;

    public bool TheGame;

    public Text CoinsText;

    void Start()
    {
        Vector3 pos = new Vector3(Random.Range(-2f, 2f), -6f, Random.Range(-2f, 2f));
        PhotonNetwork.Instantiate(PlayerPrefab.name, pos, Quaternion.identity);

        PlayerPrefs.SetInt("Coins", 0);
    }
    
    void Update()
    {
        int PlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;

       if (PhotonNetwork.InRoom)
        {
            Debug.Log("Игроков: " + PhotonNetwork.CurrentRoom.PlayerCount);
        }

        if(PhotonNetwork.CurrentRoom.PlayerCount == 1 && TheGame)
            Leave();


        CoinsText.text = "Собранно: " + PlayerPrefs.GetInt("Coins", 0) + " монет!";
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Menu");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player entered Room: " + newPlayer.NickName);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player exit the Room: " + otherPlayer.NickName);
    }
}
