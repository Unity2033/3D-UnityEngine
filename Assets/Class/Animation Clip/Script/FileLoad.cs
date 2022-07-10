using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FileLoad : MonoBehaviour
{
    public Text textUI;

    string path = "Assets/Class/Animation Clip/File/Explanation.txt";

    void Start()
    {
        textUI.text = System.IO.File.ReadAllText(path);
    }

}
