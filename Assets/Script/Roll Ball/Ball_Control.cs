using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Control : MonoBehaviour
{
    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        // AddForce : Vector의 방향과 크기로 힘을 줍니다.
        // (방향, 힘을 주는 방식) 
        // ForceMode.Impulse : Mass 무게 값이 클수록 움직이는데 더 많은 힘이 필요합니다.
        //rigid.AddForce(Vector3.up * 50, ForceMode.Impulse);

        // velocity : 현재 이동 속도 
        // rigid.velocity = new Vector3(2, 4, -1);
    }

    void FixedUpdate()
    {
        //if(Input.GetButtonDown("Jump"))
        //{
        //    rigid.AddForce(Vector3.up * 50, ForceMode.Impulse);
        //}

        Vector3 vec = new Vector3
        (
              Input.GetAxisRaw("Horizontal"),
              0,
              Input.GetAxisRaw("Vertical")
         );

        rigid.AddForce(vec, ForceMode.Impulse);

        // AddTouque : Vector 방향을 축으로 회전력이 생깁니다.
        // rigid.AddTorque(Vector3.down);
    }

}
