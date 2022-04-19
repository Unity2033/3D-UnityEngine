using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_Control : MonoBehaviour
{
    NavMeshAgent agent;

    public Transform[] Point;
    int count = 0;

    void Patrol()
    {
        if(agent.velocity == Vector3.zero)
        {
            agent.SetDestination(Point[count++].position);

            if(count >= Point.Length)
            {
                count = 0;
            }
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("Patrol", 0, 1f);
    }

    void Update()
    {
        
    }
}
