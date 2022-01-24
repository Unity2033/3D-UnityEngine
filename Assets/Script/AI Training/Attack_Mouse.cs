using UnityEngine;
using UnityEngine.AI;

public class Attack_Mouse : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] Camera camera; 

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;

            Ray ray = camera.ScreenPointToRay(Input.mousePosition); // 카메라로부터 마우스 좌표(Input.mousePosition)의 위치를 관통하는 레이저를 생성합니다.

            // Physics.Raycast() : 레이저를 발사해서 부딪히는 오브젝트를 검출합니다. 
            if (Physics.Raycast(ray, out hit)) // 레이저에 부딪히는 오브젝트가 있으면 실행됩니다.
            {
                SetDestination(hit.point);
            }
        }
    }

    void SetDestination(Vector3 dir)
    {
        agent.SetDestination(dir);
    }
}
