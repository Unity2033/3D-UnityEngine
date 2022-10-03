using Photon.Pun;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;

public class CharacterSystem : MonoBehaviourPun, IPunObservable
{
    public float speed = 5.0f;
    public float angleSpeed;
  
    public Camera temporaryCamera;
    
    public int score;

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
            score++;

            PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
                {
                    new StatisticUpdate {StatisticName = "Input_1", Value = score},
                }
            },
            (result) => { Debug.Log("값 저장 성공"); }, 
            (error) => { Debug.Log("값 저장 실패"); }
            );

            PhotonView view = other.gameObject.GetComponent<PhotonView>();

            if (view.IsMine)
            {
                PhotonNetwork.Destroy(other.gameObject);
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // 로컬 오브젝트라면 쓰기 부분이 실행됩니다.
        if(stream.IsWriting)
        {
            // 네트워크를 통해 score 값을 보냅니다.
            stream.SendNext(score);
        }
        else // 원격 오브젝트라면 읽기 부분이 실행됩니다.
        {
            // 네트워크를 통해서 score 값을 받습니다.
            score = (int)stream.ReceiveNext();
        }
    }
}


