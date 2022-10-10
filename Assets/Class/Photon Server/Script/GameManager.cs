using UnityEngine;
using Photon.Pun;

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
    }

    public void ExitGame()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {  
        PhotonNetwork.LoadLevel("Photon Room");
    }
}


