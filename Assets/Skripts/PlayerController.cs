using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    private PhotonView PhotonView;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        PhotonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PhotonView.IsMine) return;
        
        if (Input.GetKey(KeyCode.A))
        transform.Translate(Vector3.left * 3 * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
        transform.Translate(Vector3.right * 3 * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
        transform.Translate(Vector3.forward * 3 * Time.deltaTime);  
        if (Input.GetKey(KeyCode.S))
        transform.Translate(Vector3.back * 3 * Time.deltaTime);
    }
}
