using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed = 5.0f;
   
    public void Move(Vector3 Position)
    {
        agent.speed = speed;
        agent.SetDestination(Position);
    }

}
