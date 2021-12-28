using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky_Rotate : MonoBehaviour
{
    float degree;

    void Update()
    {
        degree += Time.deltaTime;

        if(degree >= 360)
        {
            degree = 0;
        }

        RenderSettings.skybox.SetFloat("_Rotation", degree);
    }
}
