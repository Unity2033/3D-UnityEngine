using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User_Interface : MonoBehaviour
{
    public GameObject Scene_Window;
    public GameObject Pause_Window; 

   public void Open_Window(string name)
   {
        switch (name)
        {
            case "Scene Window":
                Scene_Window.SetActive(true);
                break;
            case "Pause Window":
                {
                    Time.timeScale = 0.0f;
                    Pause_Window.SetActive(true);
                }
                break;
        }
   }

    public void Pause_Release()
    {
        Time.timeScale = 1.0f;
        Pause_Window.SetActive(false);
    }
   
}
