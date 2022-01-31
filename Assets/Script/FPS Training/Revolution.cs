using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolution : MonoBehaviour
{
    // 공전 기준 태양
    public GameObject Star;

    // 회전 속도
    public float speed;

    void Update()
    {
        // RotateAround(회전 기준점, 회전 축, 속도)
        transform.RotateAround(Star.transform.position, Vector3.down, speed * Time.deltaTime);
    }
}



