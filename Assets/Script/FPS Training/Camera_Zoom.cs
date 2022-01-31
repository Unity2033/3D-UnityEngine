using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Zoom : MonoBehaviour
{
    public float speed;

    Camera Main_Camera;

    void Start()
    {
        Main_Camera = GetComponent<Camera>();
    }

    void Update()
    {
        float Distance = Input.GetAxis("Mouse ScrollWheel") * -1 * speed;

        Main_Camera.fieldOfView += Distance;

        if (Main_Camera.fieldOfView >= 60)
        {
            Main_Camera.fieldOfView = 60;
        }
       
        if(Main_Camera.fieldOfView <= 40)
        {
            Main_Camera.fieldOfView = 40;
        }
    }
}
