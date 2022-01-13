using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ship : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] Transform Destination;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Destination.position);
        agent.updateRotation = false;
    }

    void Update()
    {    

    }
}
