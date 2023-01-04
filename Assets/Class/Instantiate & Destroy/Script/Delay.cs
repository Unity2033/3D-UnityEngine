using System;
using UnityEngine;
using UnityEngine.UI;

public class Delay : MonoBehaviour
{
    private Button button;
    public static Action action;

    private bool isDelay = true;
    private float fixedTime = 5f;
    private float currentTime = 5f;

    private void Start()
    {
        action = () => isDelay = false;
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (isDelay == false)
        {
            button.interactable = false;
            currentTime -= Time.deltaTime;
            button.image.fillAmount = currentTime / fixedTime;

            if (currentTime <= 0)
            {
                isDelay = true;
                button.interactable = true;
                button.image.fillAmount = currentTime = fixedTime;
            }
        }
    }
}
