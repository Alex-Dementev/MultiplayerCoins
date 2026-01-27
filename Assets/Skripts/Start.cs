using UnityEngine;
using Photon.Pun;

public class Start : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            PhotonNetwork.LoadLevel("Game");
        }
    }
}
