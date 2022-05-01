using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        int Z = Random.Range(0, 5);
        int X = Random.Range(0, 5);

        PhotonNetwork.Instantiate("Character", new Vector3(X, 1, Z), Quaternion.identity);
    }
}
