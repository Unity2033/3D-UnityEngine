using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    public Image healthGauge;

    public void State(float value)
    {
        healthGauge.fillAmount -= value;
    }

}
