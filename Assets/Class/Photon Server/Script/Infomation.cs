using Photon.Pun;
using UnityEngine.UI;

public class Infomation : MonoBehaviourPunCallbacks
{
    public Text RoomData;
    private string roomName;

    public void SetInfo(string Name, int Currecnt, int Max)
    {
        roomName = Name;
        RoomData.text = Name + " ( "+ Currecnt + " / " + Max + ")";
    }

    public void OnClickJoinRoom()
    {
        PhotonNetwork.JoinRoom(roomName);
    }
}


