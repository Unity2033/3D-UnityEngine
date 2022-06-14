using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; // 게임 내부에서 데이터 주고 받는 라이브러리
using UnityEngine.UI;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public Button connect;
    public Text currentregion;
    public Text currentlobby;

    public void Connect()
    {
        // 서버 접속
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Update()
    {
        currentregion.text = PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion;

        switch (Data.count)
        {
            case 0:
                currentlobby.text = "Fisrt Lobby";
                break;
            case 1:
                currentlobby.text = "Second Lobby";
                break;
            case 2:
                currentlobby.text = "Three Lobby";
                break;
        }
    }

    // 포톤 서버에 접속 후 호출되는 콜백 함수
    // 로비에 접속했는지 여부를 확인할 수 있습니다.
    public override void OnConnectedToMaster()
    {
        // 로비에 입장하는 함수
        //PhotonNetwork.JoinLobby();
  
        switch (Data.count)
        {
            case 0:
                // 특정 로비를 생성하여 진입하는 방법
                PhotonNetwork.JoinLobby(new TypedLobby("Lobby 1", LobbyType.Default));
                break;
            case 1:
                PhotonNetwork.JoinLobby(new TypedLobby("Lobby 2", LobbyType.Default));
                break;
            case 2:
                PhotonNetwork.JoinLobby(new TypedLobby("Lobby 3", LobbyType.Default));
                break;
        }
    }

    // 로비에 접속 후 호출되는 콜백 함수
    public override void OnJoinedLobby()
    {
        // PhotonNetwork.LoadLevel 사용하는 이유는 씬 동기화를 맞추기 위해 사용해야 합니다.
        // 일반 LoadLevel은 씬 동기화가 되지 않습니다.
 
        PhotonNetwork.LoadLevel("Photon Room");
    }
}
