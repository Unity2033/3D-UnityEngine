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

        if (Distance != 0)
        {
            Main_Camera.fieldOfView += Distance;
        }
    }
}
