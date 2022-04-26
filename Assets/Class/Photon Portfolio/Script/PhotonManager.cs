using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; // 게임 내부에서 데이터 주고 받는 라이브러리
using Photon.Realtime; // 어느 서버에 접속했을 때 이벤트를 호출하는 라이브러리

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        // 같은 버전의 유저끼리 접속을 허용합니다.
        // 같은 버전만 접속할 수 있도록 상수로 되어있는 문자열을 설정합니다.
        PhotonNetwork.GameVersion = "1.0f";

        // 유저 아이디 설정
        PhotonNetwork.NickName = "React";

        // 포톤 서버와 통신 횟수 설정 (초당 30회)
        Debug.Log(PhotonNetwork.SendRate);

        // 서버 접속
        PhotonNetwork.ConnectUsingSettings();
    }

    // 포톤 서버에 접속 후 호출되는 콜백 함수
    // 로비에 접속했는지 여부를 확인할 수 있습니다.
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");
        
        // 로비에 입장하는 함수
        PhotonNetwork.JoinLobby();
    }

    // 로비에 접속 후 호출되는 콜백 함수
    public override void OnJoinedLobby()
    {
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");

        RoomOptions Room = new RoomOptions();

        // 최대 접속자의 수를 설정합니다.
        Room.MaxPlayers = 20;

        // 룸의 오픈 여부를 설정합니다.
        Room.IsOpen = true;

        // 로비에서 룸 목록을 노출 시킬지 설정합니다.
        Room.IsVisible = true;

        // 로비에서 룸으로 입장을 할 때 룸이 없으면 생성하고, 룸이 있다면 현재 룸으로 접속하는 함수입니다.
        PhotonNetwork.JoinOrCreateRoom("Asia",Room, TypedLobby.Default); 
    }

    // 룸 생성이 완료된 후 호출되는 콜백 함수
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }

    // 랜덤한 룸으로 입장이 실패했을 때 호출되는 콜백 함수
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // 네트워크 연결이 실패했을 때 return 코드 번호를 이용해서 에러를 검출합니다.
        // 룸이 생성되지 않았을 때 호출합니다.
        Debug.Log($"JoinRandom Filed {returnCode}:{message}");
    }

    // 룸에 입장한 후 호출되는 콜백 함수
    public override void OnJoinedRoom()
    {
        Debug.Log($"PhotonNetwork.InRoom = {PhotonNetwork.InRoom}");

        int Z = Random.Range(0, 5);
        int X = Random.Range(0, 5);

        PhotonNetwork.Instantiate("Character", new Vector3(X, 1, Z),Quaternion.identity);

        // 유저가 현재 입장한 수를 출력합니다.
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");
    
        // 룸에 접속한 사용자 정보 확인
        foreach(var character in PhotonNetwork.CurrentRoom.Players)
        {
            // 사용자의 이름과 사용자의 고유 번호를 출력합니다.
            // $ : String.Format() 중괄호 안에 있는 내용을 문자열로 반환합니다.
            Debug.Log($"{character.Value.NickName},{character.Value.ActorNumber}");
        }
    }


}
