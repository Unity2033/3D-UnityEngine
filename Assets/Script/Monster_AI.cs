using UnityEngine;
using UnityEngine.AI;

public class Monster_AI : MonoBehaviour
{
    NavMeshAgent agent;

    Transform Destination;

    void Start()
    {
        Destination = GameObject.Find("Destination").GetComponent<Transform>();

        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Destination.position);
    }
}
