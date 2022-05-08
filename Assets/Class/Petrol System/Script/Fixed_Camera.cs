using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixed_Camera : MonoBehaviour
{
    // 좌표값이 true이면 target의 좌표를 설정하고, false이면 현재 좌표를 설정합니다.
    public bool x, y, z;

    public Transform target;


    void Update()
    {

        if (!target) return;

        transform.position = new Vector3(
            (x ? target.position.x : transform.position.x),
            (y ? target.position.y : transform.position.y),
            (z ? target.position.z : transform.position.z));
    }
}
