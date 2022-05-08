using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavControl : MonoBehaviour
{
    public float speed = 5.0f;
    private NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때 
        if (Input.GetMouseButtonDown(0))
        {
            // RaycastHit : 광선과 충돌한 오브젝트의 물체에 대한 정보를 저장합니다.
            RaycastHit hit;

            // 카메라로부터 스크린 공간의 마우스 포인터를 통해 위치 정보를 설정합니다.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 충돌한 물체가 있다면 Move 함수의 매개변수에 충돌한 오브젝트의 위치를 설정합니다.
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Move(hit.point);
            }
        }  
    }

    public void Move(Vector3 Position)
    {
        agent.speed = speed;
        agent.SetDestination(Position);
    }

}
