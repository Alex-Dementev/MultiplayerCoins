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
    }

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 90f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int Coins = PlayerPrefs.GetInt("Coins", 0);
            Coins++;
            PlayerPrefs.SetInt("Coins", Coins);
            PhotonNetwork.Destroy(gameObject);
        }
    }
}