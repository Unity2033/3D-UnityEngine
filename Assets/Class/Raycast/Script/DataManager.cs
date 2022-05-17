using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int money;

    private void Awake()
    {
        LoadDate();
    }

    public void SaveData()
    {
        // 유니티 내부에 key("money") value(money)를 저장합니다.
        PlayerPrefs.SetInt("money", money);
    }

    public void LoadDate()
    {
        // 유니티 내부에 저장되어 있는 "key("money")값을 불러옵니다.
        money = PlayerPrefs.GetInt("money");
    }

    // money라는 변수에 1000을 저장하는 함수입니다.
    public void Saving()
    {
        money += 1000;
        SaveData();
    }

    // money라는 변수에 1000을 감소하는 함수입니다. 
    public void Withdrawal()
    {
        money -= 1000;
        SaveData();
    }
}
