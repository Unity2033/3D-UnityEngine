using PlayFab;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;

public class PhotonSetting : MonoBehaviourPunCallbacks
{
    [SerializeField] Dropdown region;

    [SerializeField] InputField email;
    [SerializeField] InputField password;
 
    public void SignUp()
    {
        // RegisterPlayFabUserRequest : 서버에 유저를 등록하기 위한 클래스 
        var request = new RegisterPlayFabUserRequest
        {
            Email = email.text,       // 입력한 Email
            Password = password.text, // 입력한 비밀번호
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

        PhotonNetwork.GameVersion = "1.0f";

        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = region.options[region.value].text;
       
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
