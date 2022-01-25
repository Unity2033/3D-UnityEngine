using UnityEngine;
using UnityEngine.AI;

public class Monster_AI : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] GameObject Character;
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

        if (Vector3.Distance(transform.position, Character.transform.position) <= 7.5f)
        {
            transform.LookAt(Character.transform.position);
            agent.SetDestination(Character.transform.position);
        }
        else
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
}
