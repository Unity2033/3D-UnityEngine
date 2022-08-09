using UnityEngine;

public class DataSystem : MonoBehaviour
{
    public float speed;

    void Start()
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
