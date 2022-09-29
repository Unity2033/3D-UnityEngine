using Photon.Pun;
using UnityEngine;

public class CharacterSystem : MonoBehaviourPun
{
    public float speed = 5.0f;
    public float angleSpeed;

    public Camera temporaryCamera;

    private void Start()
    {
        // 현재 플레이어가 나 자신이라면 
        if(photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            temporaryCamera.enabled = false;
            GetComponentInChildren<AudioListener>().enabled = false;
        }
    }

    void Update()
    {
        if (!photonView.IsMine) return;
        
        Vector3 direction = new Vector3
            (
                 Input.GetAxis("Horizontal"),
                 0, 
                 Input.GetAxis("Vertical")
            );

        transform.Translate(direction.normalized * speed * Time.deltaTime);

        transform.eulerAngles += new Vector3
        (
           0, 
           Input.GetAxis("Mouse X") * angleSpeed * Time.deltaTime, 
           0
        );
    }
}


