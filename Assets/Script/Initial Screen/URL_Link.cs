using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URL_Link : MonoBehaviour
{
    public void Open_URL(int select)
    {
        switch(select)
        {
            case 1:
                Application.OpenURL("https://www.google.co.kr/");
                break;
            case 2:
                Application.OpenURL("https://github.com/");
                break;
            case 3:
                Application.OpenURL("https://www.youtube.com/");
                break;
        }
    }
}
