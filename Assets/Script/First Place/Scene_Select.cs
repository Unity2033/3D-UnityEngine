using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_Select : MonoBehaviour
{
    public void Scene_Number(int number)
    {
       SceneManager.LoadScene(number);   
    }
}
