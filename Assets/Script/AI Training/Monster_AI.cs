using UnityEngine;
using UnityEngine.AI;

public class Monster_AI : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform[] Destination;
    float time;
    int count;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(time > 1.0f)
        {
            Move_Ai();
            time = 0;
        }
    }   

    void Move_Ai()
    {
        if (agent.velocity == Vector3.zero)
        {
            agent.SetDestination(Destination[count++].position);

            if (count >= Destination.Length)
            {
                count = 0;
            }
        }
    }
}
