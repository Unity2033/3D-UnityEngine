using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glare : MonoBehaviour
{
    Light glare;
 

    void Start()
    {
        glare = GetComponent<Light>();
    }

    void Update()
    {
           glare.intensity = Random.Range(0.2f, 0.8f);     
    }
}
