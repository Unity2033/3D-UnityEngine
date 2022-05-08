using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public GameObject login;

    public InputField id;
    public InputField password;

    string userid = "kimgeumsoo";
    string userpassword= "1234";

    public void LoginButton()
    {
        if(id.text == userid && password.text == userpassword)
        {
            Debug.Log("로그인 성공");
            login.SetActive(false);
        }
        else
        {
            Debug.Log("로그인 실패");
        }
    }

}
