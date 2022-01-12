using UnityEngine;

public class User_Interface : MonoBehaviour
{
    public GameObject[] Window;


   public void Open_Window(string name)
   {
        Sound_System.instance.Click_Sound();

        for (int i = 0; i < Window.Length; i++)
        {
            Window[i].SetActive(false);
        }
       
        switch (name)
        {
            case "Scene Window":
                Window[0].SetActive(true);
                break;
            case "URL Window":
                Window[1].SetActive(true);
                break;
            case "Sound Window":
                Window[2].SetActive(true);
                break;
        }
   }
    public void Close_Window(string name)
    {
        switch (name)
        {
            case "Scene Window":
                Window[0].SetActive(false);
                break;
            case "URL Window":
                Window[1].SetActive(false);
                break;
            case "Sound Window":
                Window[2].SetActive(false);
                break;
        }
    }
}
