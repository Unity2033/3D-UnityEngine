using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Switching : MonoBehaviour
{
    public Image buttonImage;
    public Sprite[] buttonSprite;

    public bool state;

    public void Behaviour()
    {
        state = !state;

        if(state)
        {
            Time.timeScale = 0;
            buttonImage.sprite = buttonSprite[0];
        }
        else
        {
            Time.timeScale = 1;
            buttonImage.sprite = buttonSprite[1];
        }
    }


    public void Originally()
    {
        SceneManager.GetActiveScene();
    }
}


