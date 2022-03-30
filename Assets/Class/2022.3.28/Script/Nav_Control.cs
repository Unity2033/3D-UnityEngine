using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav_Control : MonoBehaviour
{
    public float speed = 5.0f;
    private NavMeshAgent agent;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Move(hit.point);
            }
        }  
    }

    public void Move(Vector3 Position)
    {
        agent.speed = speed;
        agent.SetDestination(Position);
    }

}
