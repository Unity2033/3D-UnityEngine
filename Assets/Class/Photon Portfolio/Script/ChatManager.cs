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

    void Start()
    {
        
    }

    void Update()
    {
   
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (input.text.Length == 0) return;

            // InputField에 있는 텍스트를 가져옵니다.
            string text = PhotonNetwork.NickName + " : " +input.text;

            // ChatPrefab을 하나 만들어서 text에 값을 설정합니다.
            GameObject chat = Instantiate(ChatPrefab);
            chat.GetComponent<Text>().text = text;

            StartCoroutine(AddChat(chat));

            input.text = "";
        }
    }

    IEnumerator AddChat(GameObject chatitem)
    {
        yield return new WaitForSeconds(0.1f);
        // 스크롤 뷰 - content에 자식으로 등록합니다.

        chatitem.transform.SetParent(ChatContent);
    }
}
