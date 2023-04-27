using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitanRobot : MonoBehaviour
{
    public Image healthGauge;
    private float health = 100.0f;

    private void Start()
    {
        healthGauge.fillAmount = health;
    }

    public void State(float value)
    {
        health -= value;
        healthGauge.fillAmount = health / 100;
    }
    

}
