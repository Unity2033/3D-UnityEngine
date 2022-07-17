using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonControl : MonoBehaviourPun
{
    public float speed = 5.0f;
    public float angleSpeed;

    public Camera cam;

    private void Start()
    {
        // 현재 플레이어가 나 자신이라면 
        if(photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
            AudioListener.volume = 1;
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
        
            float x = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 dir = new Vector3(x, 0, v);

            transform.Translate(dir.normalized * speed * Time.deltaTime);

            float mouseX = Input.GetAxis("Mouse X");

            transform.eulerAngles = new Vector3(0, mouseX * angleSpeed * Time.deltaTime, 0);         
    }
}
