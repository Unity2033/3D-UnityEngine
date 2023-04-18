using UnityEngine;
using UnityEngine.AI;

public class Obstacle : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;

    Vector3 point;
    NavMeshHit hit;

    public float life = 10.0f;
    public float range = 10.0f;

    private void Start()
    {
        InvokeRepeating("RandomPosition", 5, 1.5f);
    }

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
