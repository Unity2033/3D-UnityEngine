using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class Arrival : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;

    Vector3 point;
    NavMeshHit hit;
    public float range = 10.0f;
    public float life = 10.0f;

    public void RandomPosition()
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * range;

        if (NavMesh.SamplePosition(randomPoint, out hit, 10.0f, NavMesh.AllAreas))
        {
            point = hit.position;
        }

        navMeshAgent.destination = point;
    }
}
