using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    // 버전 입력
    private readonly string version = "1.0f";

    // 사용자 ID 입력
    private string userid = "React";

    private void Awake()
    {
        // 같은 룸의 유저들에게 자동으로 씬을 로딩해주는 함수
        PhotonNetwork.AutomaticallySyncScene = true;

        // 같은 버전의 유저끼리 접속을 허용합니다.
        // 같은 버전만 접속할 수 있도록 상수로 되어있는 문자열을 설정합니다.
        PhotonNetwork.GameVersion = version;

        // 유저 아이디 설정
        PhotonNetwork.NickName = userid;

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
       
        // 포톤 서버에 접속하거나 로비에 입장했을 때 이미 생성된 룸에서 랜덤으로 선택해서 입장하는 함수
        PhotonNetwork.JoinRandomRoom(); // 랜덤 매치 메이킹 기능 설정
    }

    // 랜덤한 룸으로 입장이 실패했을 때 호출되는 콜백 함수
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // 네트워크 연결이 실패했을 때 return 코드 번호를 이용해서 에러를 검출합니다.
        // 룸이 생성되지 않았을 때 호출합니다.
        Debug.Log($"JoinRandom Filed {returnCode}:{message}");

        // 룸의 속성 정의
        RoomOptions Room = new RoomOptions();

        // 최대 접속자의 수를 설정합니다.
        Room.MaxPlayers = 20;

        // 룸의 오픈 여부를 설정합니다.
        Room.IsOpen = true;

        // 로비에서 룸 목록을 노출 시킬지 설정합니다.
        Room.IsVisible = true;

        // 룸 생성
        PhotonNetwork.CreateRoom("My Room", Room);
    }

    // 룸 생성이 완료된 후 호출되는 콜백 함수
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }

    // 룸에 입장한 후 호출되는 콜백 함수
    public override void OnJoinedRoom()
    {
        Debug.Log($"PhotonNetwork.InRoom = {PhotonNetwork.InRoom}");

        // 유저가 현재 입장한 수를 출력합니다.
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
