using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public int count;
    public float speed = 5.0f;
    public Transform [ ] point;
    public NavMeshAgent navMeshAgent;

    private void Start()
    {
        InvokeRepeating(nameof(Move), 1, 5f);
    }

    public void Move()
    {
        if (navMeshAgent.velocity == Vector3.zero)
        {
            if (point.Length <= count)
            {
                 count = 0;
            }

            navMeshAgent.SetDestination(point[count++].position);
        }
    }

}
