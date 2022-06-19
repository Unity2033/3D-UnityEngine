using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Arrival : MonoBehaviour
{
    NavMeshAgent agent;

    public Transform arrive;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(arrive.position);
    }
}
