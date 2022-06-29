using UnityEngine;

public class LightManager : MonoBehaviour
{
    bool condition = false;
    public GameObject [] lightEffect;

    public void LightSetting(int number)
    {   
        condition = !condition;

        if (condition)
        {
            lightEffect[number].SetActive(true);
        }
        else
        {
            lightEffect[number].SetActive(false);
        }
    }
}
