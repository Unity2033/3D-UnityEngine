using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class Text_Management : MonoBehaviour
{
    Dictionary<int, string> Data = new Dictionary<int, string>();
    public Text[] Select_Scene_data;

    void Start()
    {
        Select_Scene_Text();


        foreach (KeyValuePair<int, string> data in Data)
        {
            Select_Scene_data[data.Key].text = data.Value;        
        }
    }

    void Select_Scene_Text()
    {
        Data.Add(0, "Bird Guess");
        Data.Add(1, "Roll Ball");
        Data.Add(2, "Planetary Defence");
        Data.Add(3, "Dangerous Escape");
    }


}
