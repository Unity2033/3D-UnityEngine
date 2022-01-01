using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{
    public static int Level;
    public Slider Experience;
    public Text Current_Text, Next_Text;
    public Bird_Manager bird;


    private void Awake()
    {
        Level = PlayerPrefs.GetInt("Current_Level", 1);
        bird = GameObject.Find("Bird Manager").GetComponent<Bird_Manager>();
    }

    private void Update()
    {
        Current_Text.text = Level.ToString();
        Next_Text.text = (Level + 1).ToString();

        Experience.value = bird.score;
    }
}
