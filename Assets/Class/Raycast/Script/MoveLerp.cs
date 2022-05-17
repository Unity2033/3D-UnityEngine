using UnityEngine;

public class MoveLerp : MonoBehaviour
{
    public GameObject point;
    public float speed = 1.0f;

    void Update()
    {
        // 현재 자기 자신의 위치 = 현재 위치, 도착 위치, 도착하기 위한 속도
        transform.position = Vector3.Lerp(transform.position, point.transform.position, speed * Time.deltaTime);
    }
}
