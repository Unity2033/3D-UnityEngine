using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public int count;
    public Transform [ ] point;
    public NavMeshAgent navMeshAgent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            navMeshAgent.SetDestination(point[++count % 3].position);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Fox"))
        {
            Debug.Log("냥");
        }
    }
}
