using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public Camera mainCamera; //메인 카메라
    public float maxSpeed; //최대 속도
    public float aclrt; // 가속도

    private float curr_speed; //현재 속도
    private Vector3 dir; // 방향

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 targetPos = new Vector3(hit.point.x - transform.position.x, 0f, hit.point.z - transform.position.z); // 방향구하기
                curr_speed = Mathf.Clamp(curr_speed += aclrt * Time.deltaTime, 0f, maxSpeed); //가속
                dir = targetPos.normalized; //방향 설정
            }
        }
        else
        {
            curr_speed = Mathf.Clamp(curr_speed -= aclrt * Time.deltaTime, 0f, maxSpeed); //감속
        }

        transform.Translate(dir * curr_speed * Time.deltaTime, Space.World); //이동
    }
}

