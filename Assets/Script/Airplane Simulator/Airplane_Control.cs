using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane_Control : MonoBehaviour
{
    float speed = 10.0f;

    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");     

        transform.Translate(new Vector3(Horizontal, 0, Vertical) * Time.deltaTime * speed);

        // transform.position : 지정한 위치로 이동시킵니다.

        // transform.Translate : 프레임마다 일정 속도를 가지고 일정거리만큼 계속 이동하는 함수입니다. 
        // transform.Translate의 인수로는 이동할 방향과 속력을 의미합니다.
        //transform.Translate(0, 0, 0.1f);

        // 스크립트에서 회전은 쿼터니온 형식을 사용하며 벡터와는 다른 사원수 체계를 이용해 오브젝트를 회전시킵니다.
        // 3차원 벡터를 이용해서 회전을 다루는 방법은 오일러 각 체계로 회전시킵니다.
        //transform.rotation = Quaternion.Euler(0f, (Mathf.Cos(1) * 0.5f + 0.5f) * 360f, 0f);
    }
}
