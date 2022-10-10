using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSystem : MonoBehaviourPun, IPunObservable
{
    public float speed = 5.0f;
    public float angleSpeed;

    public int score;
    public Camera temporaryCamera;
    [SerializeField] Text scoreText;
    
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

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // 로컬 오브젝트라면 쓰기 부분이 실행됩니다.
        if (stream.IsWriting)
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

    public void PlayfabDataSave()
    {
        if (photonView.IsMine) score++;
     
        PlayFabClientAPI.UpdatePlayerStatistics
        (
            new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
                {
                         new StatisticUpdate
                         {
                             StatisticName = "Score", 
                             Value = score
                         },
                }
            },
           (result) => { scoreText.text = "Current Crystal : " + score.ToString(); },
           (error) => { scoreText.text = "No value saved."; }
       );
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Crystal(Clone)")
        {
            PlayfabDataSave();

            PhotonView view = other.gameObject.GetComponent<PhotonView>();

            if (view.IsMine)
            {
                PhotonNetwork.Destroy(other.gameObject);
            }
        }      
    }
}


