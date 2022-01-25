using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Training : MonoBehaviour
{
    public Light the_light;

    float target_intensity;
    float currnet_intensity;

    void Start()
    {
        currnet_intensity = the_light.intensity;
        target_intensity = Random.Range(0.4f, 1f);
    }

    void Update()
    {
        if(Mathf.Abs(target_intensity - currnet_intensity) >= 0.01)
        {
            if(target_intensity - currnet_intensity >= 0)
                currnet_intensity += Time.deltaTime * 3f;
            else
                currnet_intensity -= Time.deltaTime * 3f;

            the_light.intensity = currnet_intensity;
            the_light.range = currnet_intensity + 10; 
        }
        else
        {
            target_intensity = Random.Range(0.4f, 1f);
        }
    }
}
