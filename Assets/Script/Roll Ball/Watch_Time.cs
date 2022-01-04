using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Watch_Time : MonoBehaviour
{
    public Text Watch;
    float current_time = 60;

    int Max_score = 0;
    int Current_score = 0;

    GameManager manager;
    public GameObject Result_Window;
    public Text Best_Score, Current_Score;

    private void Start()
    {
        Time.timeScale= 1;

        Max_score = PlayerPrefs.GetInt("Max_Score", 0);
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        current_time -= Time.deltaTime;
        Watch.text = current_time.ToString("F2");

        if(current_time <= 0.0f)
        {
            current_time = 0;
            Time.timeScale = 0;
            Result_Window.SetActive(true);
        }

        Current_score = manager.Score;
        Best_Score.text = "Best Score : " + Max_score.ToString();
        Current_Score.text = "Current Score : " + Current_score.ToString();

        if (Max_score < Current_score)
        {
            Max_score = Current_score;
            PlayerPrefs.SetInt("Max_Score", Max_score);
        }
    }
}
