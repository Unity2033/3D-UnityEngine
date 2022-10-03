using UnityEngine;
using Photon.Pun;
using System.Collections;
public class GameManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.Instantiate("Character", new Vector3
            (
                 Random.Range(0, 5), 
                 1, 
                 Random.Range(0, 5)), 
                 Quaternion.identity
            );

        StartCoroutine(nameof(ObjectCreation));
    }

    public void ExitGame()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Photon Room");
    }

    private IEnumerator ObjectCreation()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            while(true)
            {
                PhotonNetwork.Instantiate("Crystal",new Vector3(0,0,5),Quaternion.identity);
                yield return new WaitForSeconds(5f);             
            }
        }
    }
    


}


