using Photon.Pun;
using UnityEngine.UI;

public class Infomation : MonoBehaviourPunCallbacks
{
    public Text roomData;
    private string roomName;

    public void SetInfo(string Name, int Currecnt, int Max)
    {
        roomName = Name;
        roomData.text = Name + " ( "+ Currecnt + " / " + Max + ")";
    }

    public void OnClickJoinRoom()
    {
        PhotonNetwork.JoinRoom(roomName);
    }
}


