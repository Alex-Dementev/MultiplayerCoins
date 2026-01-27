using UnityEngine;
using Photon.Pun;

public class CoinsManager : MonoBehaviour
{
    private float minSpeed = 30f;
    private float maxSpeed = 120f;

    private float rotationSpeed;

    void Start()
    {
        // Случайная скорость
        rotationSpeed = Random.Range(minSpeed, maxSpeed);

        // Случайное направление (влево или вправо)
        if (Random.value < 0.5f)
            rotationSpeed *= -1f;

        transform.rotation = Quaternion.Euler(0f, 0f, 90f);

        int CoinsCount = PlayerPrefs.GetInt("CoinsCount", 0);
        CoinsCount++;
        PlayerPrefs.SetInt("CoinsCount", CoinsCount);
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int Coins = PlayerPrefs.GetInt("Coins", 0);
            Coins++;
            PlayerPrefs.SetInt("Coins", Coins);
            int CoinsCount = PlayerPrefs.GetInt("CoinsCount", 0);
            CoinsCount -= 1;
            PlayerPrefs.SetInt("CoinsCount", CoinsCount);
            PhotonNetwork.Destroy(gameObject);
        }
    }
}