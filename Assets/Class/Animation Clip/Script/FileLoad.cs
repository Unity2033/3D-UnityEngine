using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileLoad : MonoBehaviour
{
    public Text [] textGUI;

    public string [] path;

    void Start()
    {
        for(int i = 0; i < textGUI.Length; i++)
        {
            textGUI[i].text = System.IO.File.ReadAllText(path[i]);
        }
    }
}


