using UnityEngine;

public class Game_End : MonoBehaviour
{
    public void Game_Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
   
}
