using System;
using UnityEditor;
using UnityEngine;

public class Capture : MonoBehaviour
{
    public void ScreenShot()
    {
          ScreenCapture.CaptureScreenshot
          (
                 "Assets/Class/Mouse Drag Function/Texture" +
                 DateTime.Now.Second + 
                 DateTime.Now.Millisecond + 
                 ".png"
          );

        EditorApplication.ExecuteMenuItem("Assets/Refresh");
    }
}


