using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; // 게임 내부에서 데이터 주고 받는 라이브러리
using UnityEngine.UI;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public InputField ID;
    public Button connect;

    private void Start()
    {
        connect.interactable = false;
    }

    private void Update()
    {
        if (ID.text.Length != 0)
        {
            connect.interactable = true;
        }
    }

    public void Connect()
    {
        PhotonNetwork.AutomaticallySyncScene = false;

        // 같은 버전의 유저끼리 접속을 허용합니다.
        // 같은 버전만 접속할 수 있도록 상수로 되어있는 문자열을 설정합니다.
        PhotonNetwork.GameVersion = "1.0f";

        // 유저 아이디 설정
        PhotonNetwork.NickName = ID.text;

        // 서버 접속
        PhotonNetwork.ConnectUsingSettings();
    }

    // 포톤 서버에 접속 후 호출되는 콜백 함수
    // 로비에 접속했는지 여부를 확인할 수 있습니다.
    public override void OnConnectedToMaster()
    {
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");

        // 로비에 입장하는 함수
        PhotonNetwork.JoinLobby();

        // 특정 로비를 생성하여 진입하는 방법
        //PhotonNetwork.JoinLobby(new TypedLobby("EU",LobbyType.Default));
    }

    // 로비에 접속 후 호출되는 콜백 함수
    public override void OnJoinedLobby()
    {
        // PhotonNetwork.LoadLevel 사용하는 이유는 씬 동기화를 맞추기 위해 사용해야 합니다.
        // 일반 LoadLevel은 씬 동기화가 되지 않습니다.\

         PhotonNetwork.LoadLevel("Lobby");
  

    }
}
