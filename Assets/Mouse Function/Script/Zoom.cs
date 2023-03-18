using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    void Update()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * 10;

        mainCamera.fieldOfView = Mathf.Clamp
                     (
                         mainCamera.fieldOfView,     
                         20.0f,
                         60.0f
                     );

        mainCamera.fieldOfView += distance;    
    }
}




