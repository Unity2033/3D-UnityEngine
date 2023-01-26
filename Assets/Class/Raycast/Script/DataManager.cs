using UnityEngine;
using System.Text;

public class DataManager : MonoBehaviour
{
    private int score;

    void Awake()
    {
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    public void Load()
    {
        score = PlayerPrefs.GetInt("Score");
    }

 
}
