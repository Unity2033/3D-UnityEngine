using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Watch_Time : MonoBehaviour
{
    public Text Watch;
    float current_time = 60;

    void Update()
    {
        current_time -= Time.deltaTime;
        Watch.text = current_time.ToString("F2");

        if(current_time <= 0.0f)
        {
            current_time = 0;
        }
    }
}
