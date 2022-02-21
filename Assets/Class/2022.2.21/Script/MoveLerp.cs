using UnityEngine;

public class MoveLerp : MonoBehaviour
{
    public GameObject point;
    public float speed = 1.0f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, point.transform.position, speed * Time.deltaTime);
    }
}
