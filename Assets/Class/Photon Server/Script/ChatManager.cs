using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ChatManager : MonoBehaviourPunCallbacks
{
    public InputField input;
    public GameObject ChatPrefab;
    public Transform ChatContent;

    void Update()
    { 
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (input.text.Length == 0) return;

            // InputField에 있는 텍스트를 가져옵니다.
            string chat = PhotonNetwork.NickName + " : " +input.text;

            // RpcTarget.All : 현재 룸에 있는 모든 클라이언트에게 RpcAddChat함수를 실행하라는 명령을 합니다.
            photonView.RPC("RpcAddChat", RpcTarget.All, chat);
        }
    }

    [PunRPC]
    void RpcAddChat(string msg)
    {
        // ChatPrefab을 하나 만들어서 text에 값을 설정합니다.
        GameObject chat = Instantiate(ChatPrefab);
        chat.GetComponent<Text>().text = msg;

        // 스크롤 뷰 - content에 자식으로 등록합니다.
        chat.transform.SetParent(ChatContent);

        // 채팅을 입력한 후에도 이어서 입력할 수 있도록 설정합니다.
        input.ActivateInputField();

        // input 텍스트를 초기화합니다.
        input.text = "";
    }
}
