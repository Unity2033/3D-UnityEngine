using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonControl : MonoBehaviourPun
{
    public float speed = 5.0f;
    public float angleSpeed;
    public int health = 100;

    public Camera cam;
    public GameObject effect;
    public LayerMask layer;

    RaycastHit hit;

    private void Start()
    {
        // 현재 플레이어가 나 자신이라면 
        if(photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            cam.enabled = false;
            GetComponentInChildren<AudioListener>().enabled = false;
        }
    }

    void Update()
    {
        if (!photonView.IsMine) return;
        
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.Translate(dir.normalized * speed * Time.deltaTime);

        transform.eulerAngles += new Vector3
        (
           0, Input.GetAxis("Mouse X") * angleSpeed * Time.deltaTime, 0
        );

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, layer))
            {         
                PhotonControl control = hit.transform.GetComponent<PhotonControl>();

                if(control == null)
                {
                    return;
                }

                GameObject hitEffect = Instantiate(effect);

                hitEffect.transform.position = hit.point;

                control.photonView.RPC("Damage", RpcTarget.All);

                Destroy(hitEffect,0.1f);
            }
        }

        if (health <= 0)
        {
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.Disconnect();
        }     
    }

    [PunRPC]
    public void Damage()
    {
        health -= 10;
    }

}


