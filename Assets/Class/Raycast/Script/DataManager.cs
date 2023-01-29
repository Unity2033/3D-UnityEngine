using UnityEngine;

public enum Level
{
    Level1,
    Level2,
    Level3
}

public class DataManager : MonoBehaviour
{
    public int score;
    Texture2D cursor;
    public Level state;

    void Awake()
    {
        Load();
    }

    public void LevelStatus()
    {
        switch (state)
        {
            case Level.Level1 : cursor = Resources.Load<Texture2D>("Basic");
                break;
            case Level.Level2 : cursor = Resources.Load<Texture2D>("Hand");
                break;
            case Level.Level3 : cursor = Resources.Load<Texture2D>("Shoot");
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
