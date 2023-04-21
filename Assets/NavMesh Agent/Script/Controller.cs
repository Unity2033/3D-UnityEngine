using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public int count;
    public Transform [ ] point;
    public NavMeshAgent navMeshAgent;

    private void OnTriggerEnter(Collider other)
    {
        ColliderEffect colliderEffect = other.GetComponent<ColliderEffect>();

        if(colliderEffect != null)
        {
            navMeshAgent.SetDestination(colliderEffect.ArrivalPosition(point[count++].position));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ColliderEffect colliderEffect = other.GetComponent<ColliderEffect>();

        if (colliderEffect != null)
        {
            if (point.Length <= count)
            {
                count = 0;
            }
        }
    }

}
