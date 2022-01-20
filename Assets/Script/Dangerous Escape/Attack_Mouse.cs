using UnityEngine;
using UnityEngine.AI;

public class Attack_Mouse : MonoBehaviour
{
    bool Move_Where;
    NavMeshAgent agent;
    Vector3 destination;

    [SerializeField] Camera camera;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SetDestination(hit.point);
            }
        }

        Look_Move_Direction();
    }

    void SetDestination(Vector3 dir)
    {
        agent.SetDestination(dir);
        destination = dir;
        Move_Where = true;
    }

    private void Look_Move_Direction()
    {
        if (agent.velocity.magnitude == 0f) // 목적지에 도착하게 되면 함수를 종료합니다.
         {
            Move_Where = false;
            return; 
        }

        if (Move_Where)
        {
            var dir =new Vector3(agent.steeringTarget.x, agent.steeringTarget.y, agent.steeringTarget.z) - transform.position;
            transform.forward = dir;         
        }
    }
}
