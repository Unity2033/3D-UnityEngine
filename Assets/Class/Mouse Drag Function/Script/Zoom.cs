using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * 10;

        mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, 20.0f, 60.0f);

        mainCamera.fieldOfView += distance;    
    }
}

