using Photon.Pun; // 게임 내부에서 데이터 주고 받는 라이브러리
using UnityEngine.UI;
using Photon.Realtime;

public class ConnectServer : MonoBehaviourPunCallbacks
{
    public Text lobbyName;
    public string lobbyType;

    private void Start()
    {
        lobbyName.text = lobbyType;
    }

    public void SelectLobby()
    {
        // 서버 접속
        PhotonNetwork.ConnectUsingSettings();

        // JoinLobby : 특정 로비를 생성하여 진입하는 방법
        PhotonNetwork.JoinLobby(new TypedLobby(lobbyType, LobbyType.Default));

        // PhotonNetwork.LoadLevel 사용하는 이유는 씬 동기화를 맞추기 위해 사용해야 합니다.
        // 일반 LoadLevel은 씬 동기화가 되지 않습니다.
        PhotonNetwork.LoadLevel("Photon Room");
    }
}
