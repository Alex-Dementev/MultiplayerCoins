using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    private PhotonView photonView;

    public float Speed = 4f;
    private DynamicJoystick Joystick;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        Joystick = FindObjectOfType<DynamicJoystick>();
    }

    void Update()
    {
        if (!photonView.IsMine) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Если есть джойстик и его двигают — используем его
        if (Joystick != null && (Mathf.Abs(Joystick.Horizontal) > 0.1f || Mathf.Abs(Joystick.Vertical) > 0.1f))
        {
            h = Joystick.Horizontal;
            v = Joystick.Vertical;
        }

        Vector3 direction = new Vector3(h, 0, v).normalized;

        transform.Translate(direction * Speed * Time.deltaTime, Space.World);
    }
}