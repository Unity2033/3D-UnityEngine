using UnityEngine;

public class LightManager : MonoBehaviour
{
    bool condition = false;
    public GameObject [] lightEffect;

    public void LightSetting(int number)
    {   
        condition = !condition;

        lightEffect[number].SetActive(condition);
    }
}


