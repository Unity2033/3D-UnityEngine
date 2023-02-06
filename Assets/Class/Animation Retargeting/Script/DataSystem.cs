using UnityEngine;

public class DataSystem : MonoBehaviour
{
    private float speed;

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }

    }


    void Awake()
    {
        Load();
    }
   
    public void Save()
    {
        PlayerPrefs.SetFloat("speed", speed);
    }

    public void Load()
    {
        speed = PlayerPrefs.GetFloat("speed");
    }
}
