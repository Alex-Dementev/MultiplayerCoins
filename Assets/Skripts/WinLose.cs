using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class WinLose : MonoBehaviour
{
    public Text WinLoseText;

    private float DelayToLeave;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.GetInt("Coins", 0) >= 10)
            WinLoseText.text = "Ты выйграл!!!";
        else
            WinLoseText.text = "Ты проиграл";
    }

    // Update is called once per frame
    void Update()
    {
        DelayToLeave += Time.deltaTime;

        if(DelayToLeave >= 5.5f)
        {
            PhotonNetwork.LoadLevel("Lobby");
        }
    }
}
