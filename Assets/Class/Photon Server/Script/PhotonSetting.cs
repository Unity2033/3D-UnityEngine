using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PhotonSetting : MonoBehaviourPunCallbacks
{
    public InputField id;
    public InputField region;
    public Button connect;

    public void Connect()
    {
        PhotonNetwork.AutomaticallySyncScene = false;

        // 같은 버전의 유저끼리 접속을 허용합니다.
        // 같은 버전만 접속할 수 있도록 상수로 되어있는 문자열을 설정합니다.
        PhotonNetwork.GameVersion = "1.0f";

        // 유저 아이디 설정
        PhotonNetwork.NickName = id.text;

        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = region.text;
        
        // 서버 접속
        PhotonNetwork.LoadLevel("Photon Lobby"); 
    }

    void Update()
    {
        if (id.text.Length != 0 && region.text.Length != 0)
        {
            connect.interactable = true;
        }
        else
        {
            connect.interactable = false;
        }
    
        Debug.Log(PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion);
    }
}
