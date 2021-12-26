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
                Pause_Window.SetActive(true);
                break;

        }
   }
   
}
