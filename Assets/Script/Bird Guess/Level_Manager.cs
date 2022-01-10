using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    public static int Level = 1;
    public Slider Experience;
    public Text Current_Text, Next_Text;
    public Bird_Manager bird;
    public GameObject Result_Window;
    public Sprite [] Scenery;
    public Image Buffer;

    private void Awake()
    {
        Time.timeScale = 1;

        Current_Text.text = Level.ToString();
        Next_Text.text = (Level + 1).ToString();
    }

    private void Update()
    {
        Experience.value = bird.score;

        if(bird.score >= 100)
        {           
            Result_Window.SetActive(true);         
            Time.timeScale = 0;
        }

        switch (Level)
        {
            case 1:
                Buffer.sprite = Scenery[0];
                break;
            case 2:
                Buffer.sprite = Scenery[1];
                break;
            case 3:
                Buffer.sprite = Scenery[2];
                break;
        }
    }

    public void Next_Stage()
    {
        Level++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
    }
}
