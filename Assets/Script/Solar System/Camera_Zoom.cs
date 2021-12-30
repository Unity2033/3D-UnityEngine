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

        if(Distance != 0)
        {
            Main_Camera.fieldOfView += Distance;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = new Vector3(50, 35, -50);
            transform.rotation = Quaternion.Euler(35, 35, 0);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(-75, 100f, -50);
            transform.rotation = Quaternion.Euler(-50, 50, 0);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(0, 90f, -75);
            transform.rotation = Quaternion.Euler(20, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(0, 82.5f, -175);
            transform.rotation = Quaternion.Euler(25, 0, 0);
        }
    }
}
