using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Select : MonoBehaviour
{
    public InputField input; 
    
    public void Scene_Number()
    {
       SceneManager.LoadScene(int.Parse(input.text));   
    }
}
