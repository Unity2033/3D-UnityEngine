using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public int count;
    public Transform [ ] point;
    public NavMeshAgent navMeshAgent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            navMeshAgent.SetDestination(point[count++].position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (point.Length <= count)
            {
                count = 0;
            }
        }
    }

}
