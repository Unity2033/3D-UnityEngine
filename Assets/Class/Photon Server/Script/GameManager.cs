using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        int Z = Random.Range(50, 60);
        int X = Random.Range(50, 60);

        PhotonNetwork.Instantiate("Character", new Vector3(X, 1, Z), Quaternion.identity);
    }
}
