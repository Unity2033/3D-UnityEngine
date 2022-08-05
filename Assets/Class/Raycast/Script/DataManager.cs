using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public int money;
    public int hat;
    public int stick;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        LoadDate();
    }

    public void SaveData()
    {
        // 유니티 내부에 key(" ") value( )를 저장합니다.
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("hat", hat); 
        PlayerPrefs.SetInt("stick", stick);
    }

    public void LoadDate()
    {
        // 유니티 내부에 저장되어 있는 key(" ")값을 불러옵니다.
        money = PlayerPrefs.GetInt("money");
        hat = PlayerPrefs.GetInt("hat");
        stick = PlayerPrefs.GetInt("stick");
    }

    public void IncreaseMoney()
    {
        money += 100;
        SaveData();
    }
}
