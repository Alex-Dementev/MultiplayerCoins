using UnityEngine;
using Photon.Pun;

public class MasterClient : MonoBehaviour
{
    public GameObject CoinsSpawner;

    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            CoinsSpawner.SetActive(true);
        }
        else
        {
            CoinsSpawner.SetActive(false);
        }
    }
}
