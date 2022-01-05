using UnityEngine;
using UnityEngine.UI;

public class Watch_Time : MonoBehaviour
{
    public Text Watch;

    public GameObject Result_Window;
    public Text Best_Score, Current_Score;

   GameManager manager;
  
    private void Start()
    {
        Time.timeScale= 1;
        manager.Max_score = PlayerPrefs.GetInt("Max_Score", 0);
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        manager.current_time -= Time.deltaTime;
        Watch.text = manager.current_time.ToString("F2");

        if(manager.current_time <= 0.0f)
        {
            Time.timeScale = 0;
            manager.current_time = 0;
            Result_Window.SetActive(true);
        }

        Best_Score.text = "Best Score : " + manager.Max_score.ToString();
        Current_Score.text = "Current Score : " + manager.Score.ToString();

        if (manager.Max_score < manager.Score)
        {
            manager.Max_score = manager.Score;
            PlayerPrefs.SetInt("Max_Score", manager.Max_score);
        }
    }
}
