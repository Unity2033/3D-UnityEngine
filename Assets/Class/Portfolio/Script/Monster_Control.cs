using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_Control : MonoBehaviour
{
    NavMeshAgent agent;

    public Transform[] Point;
    public GameObject Character;
    int count = 0;

    Transform Target = null;

    public void Settarget(Transform p_target)
    {
        CancelInvoke();
        Target = p_target;         
    }

    public void Resettarget()
    {
        Target = null;
        InvokeRepeating("Patrol", 0, 1f);
    }

    void Patrol()
    {
        if (Target == null)
        {
            if (agent.velocity == Vector3.zero)
            {
                agent.SetDestination(Point[count++].position);

                if (count >= Point.Length)
                {
                    count = 0;
                }
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
        if(Vector3.Distance(transform.position, Character.transform.position) <= 10)
        {
             Settarget(Character.transform);
        }
        else
        {
            Resettarget();
        }

        if(Target != null)
        {
            agent.SetDestination(Target.position);
        }
    }
}
