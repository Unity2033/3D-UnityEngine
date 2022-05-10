using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PhotonSetting : MonoBehaviourPunCallbacks
{
    public InputField email;
    public InputField password;
    public InputField username;
    public InputField region;
   
    public void SignUp()
    {
        // RegisterPlayFabUserRequest : 서버에 유저를 등록하기 위한 클래스 
        var request = new RegisterPlayFabUserRequest
        {
            Email = email.text,       // 입력한 Email
            Password = password.text, // 입력한 비밀번호
            Username = username.text  // 입력한 유저 이름
        };

        PlayFabClientAPI.RegisterPlayFabUser
        (
            request,       // 회원 가입에 대한 정보
            SignUpSuccess, // 회원 가입이 성공했을 때 함수
            SignUpFailure  // 회원 가입이 실패했을 때 함수
        );
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email.text,
            Password = password.text,
        };

        PlayFabClientAPI.LoginWithEmailAddress
            (
              request,
              LoginSuccess,
              LoginFailure
            );
     }

    public void LoginSuccess(LoginResult result)
    {
        PhotonNetwork.AutomaticallySyncScene = false;

        // 같은 버전의 유저끼리 접속을 허용합니다.
        // 같은 버전만 접속할 수 있도록 상수로 되어있는 문자열을 설정합니다.
        PhotonNetwork.GameVersion = "1.0f";

        // 유저 아이디 설정
        PhotonNetwork.NickName = username.text;

        // 입력한 지역을 설정합니다.
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = region.text;
       
        // 서버 접속
        PhotonNetwork.LoadLevel("Photon Lobby"); 
    }

    public void LoginFailure(PlayFabError error)
    {
        Debug.Log("로그인 실패");
    }

    public void SignUpSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("회원 가입 성공");
    }

    public void SignUpFailure(PlayFabError error)
    {
        Debug.Log("회원 가입 실패");
    }
}
