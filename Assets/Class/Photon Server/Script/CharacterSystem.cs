using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Crystal(Clone)")
        {
            if (photonView.IsMine)
            {
                UIManager.instance.score++;
            }

            PlayFabClientAPI.UpdatePlayerStatistics
            (
                new UpdatePlayerStatisticsRequest
                {
                    Statistics = new List<StatisticUpdate>
                    {
                         new StatisticUpdate
                         {
                             StatisticName = "Score", Value = UIManager.instance.score
                         },
                    }
                },
               (result) =>
               {
                   UIManager.instance.scoreText.text = "Current Crystal : " + UIManager.instance.score.ToString();
               },
               (error) =>
               {
                   UIManager.instance.scoreText.text = "No value saved.";
               }
           );

            PhotonView view = other.gameObject.GetComponent<PhotonView>();

            if (view.IsMine)
            {
                PhotonNetwork.Destroy(other.gameObject);
            }
        }
        
    }
}


