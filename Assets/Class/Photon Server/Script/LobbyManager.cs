using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime; // 어느 서버에 접속했을 때 이벤트를 호출하는 라이브러리

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public string nickName;

    public Button RoomCreate;
    public Transform RoomContent;
    public GameObject RoomPrefab, namePanel;
    public InputField RoomName, RoomPerson, GameID;

    // 룸 목록을 저장하기 위한 자료구조
    Dictionary<string, RoomInfo> RoomCatalog = new Dictionary<string, RoomInfo>();

    private void Start()
    {
        // 유저 아이디 설정
        PhotonNetwork.NickName = PlayerPrefs.GetString("Name");

        if (PhotonNetwork.NickName.Length == 0)
        {
            namePanel.SetActive(true);
        }
    }

    void Update()
    {
        if(RoomName.text.Length > 0 && RoomPerson.text.Length > 0)
            RoomCreate.interactable = true;
        else
            RoomCreate.interactable = false;
    }

    public void NickNameSetting()
    {
        // 유저 아이디 설정
        PhotonNetwork.NickName = nickName = GameID.text;

        PlayerPrefs.SetString("Name", nickName);

        if (PhotonNetwork.NickName.Length != 0)
        {
            namePanel.SetActive(false);
        }
    }

    public void OnClickCreateRoom()
    {
        // 룸 옵션을 설정합니다.
        RoomOptions Room = new RoomOptions();

        // 최대 접속자의 수를 설정합니다.
        Room.MaxPlayers = byte.Parse(RoomPerson.text);

        // 룸의 오픈 여부를 설정합니다.
        Room.IsOpen = true;

        // 로비에서 룸 목록을 노출 시킬지 설정합니다.
        Room.IsVisible = true;

        // 룸을 생성하는 함수
        PhotonNetwork.CreateRoom(RoomName.text, Room);
    }

    // 해당 로비에 방 목록의 변경 사항이 있으면 호출(추가, 삭제, 참가)
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {        
       AllDeleteRoom();
       UpdateRoom(roomList);
       CreateRoomObject();
    }

    void UpdateRoom(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            // 해당 이름이 RoomCatalog의 key 값으로 설정되어 있다면
            if (RoomCatalog.ContainsKey(roomList[i].Name))
            {
                // RemovedFromList : (true) 룸에서 삭제가 되었을 때
                if (roomList[i].RemovedFromList)
                {
                    RoomCatalog.Remove(roomList[i].Name);
                    continue;
                }
            }

            RoomCatalog[roomList[i].Name] = roomList[i];
        }
    }

    public void AllDeleteRoom()
    {
        // Transform 오브젝트에 있는 하위 오브젝트에 접근하여 전체 삭제를 시도합니다.
        foreach(Transform trans in RoomContent)
        {
            // Transform이 가지고 있는 게임 오브젝트를 삭제합니다.
            Destroy(trans.gameObject);
        }
    }

    // 룸에 입장한 후 호출되는 콜백 함수
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Photon Game");
    }

    public void CreateRoomObject()
    {
        // RoomCatalog에 여러 개의 Value값이 들어가있다면 RoomInfo에 넣어줍니다.
        foreach (RoomInfo info in RoomCatalog.Values)
        {
            // 룸을 생성합니다.
            GameObject room = Instantiate(RoomPrefab);

            // RoomContect의 하위 오브젝트로 설정합니다.
            room.transform.SetParent(RoomContent);

            // 룸 정보를 입력합니다.
            room.GetComponent<Infomation>().SetInfo(info.Name, info.PlayerCount, info.MaxPlayers);
        }
    }
}
