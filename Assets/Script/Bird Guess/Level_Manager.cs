using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    public static int Level = 1;

    public Image Buffer;
    public Sprite[] Scenery;
    public Bird_Manager bird;
    public Slider Experience;
    public GameObject Result_Window;
    public Text Current_Text, Next_Text;

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
