using UnityEngine;
using System.Text;

public class DataManager : MonoBehaviour
{
    Texture2D cursor;
    public int score;

    void Awake()
    {
        Load();
    }

    private void Update()
    {
        int count = score % 3;

        switch (count)
        {
            case 0:
                cursor = Resources.Load<Texture2D>("Basic");
                break;
            case 1:
                cursor = Resources.Load<Texture2D>("Hand");
                break;
            case 2:
                cursor = Resources.Load<Texture2D>("Shoot");
                break;
        }

        Cursor.SetCursor(cursor, new Vector2(0, 0), CursorMode.Auto);
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
