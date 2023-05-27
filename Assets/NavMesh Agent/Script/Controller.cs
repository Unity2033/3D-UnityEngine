using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public int count;
    public Transform [ ] point;
    public NavMeshAgent navMeshAgent;

    private void Start()
    {
        InvokeRepeating("Move", 1, 2.5f);
    }

    public void Move()
    {
        if (navMeshAgent.velocity == Vector3.zero)
        {
            navMeshAgent.SetDestination(point[count++ % 3].position);
        }
    }
}
