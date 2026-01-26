using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class CreateCoins : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;

    void Start()
    {
        Vector3 pos = new Vector3(Random.Range(-5f, 5f), -10f, Random.Range(-2f, 12f));
        PhotonNetwork.Instantiate(PlayerPrefab.name, pos, Quaternion.identity);
        pos = new Vector3(Random.Range(-5f, 5f), -10f, Random.Range(-2f, 12f));
        PhotonNetwork.Instantiate(PlayerPrefab.name, pos, Quaternion.identity);
    }
    
    void Update()
    {
        int PlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;

       if (PhotonNetwork.InRoom)
        {
            Debug.Log("Игроков: " + PhotonNetwork.CurrentRoom.PlayerCount);
        }
    }
}
