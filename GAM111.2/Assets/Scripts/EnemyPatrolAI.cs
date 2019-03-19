using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolAI : MonoBehaviour
{
    public Transform player;
    public Transform[] waypoints;
    NavMeshAgent agent;
    int index;
    public float alertionDistance = 10;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        index = 0;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position,player.position) < alertionDistance)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if (Vector3.Distance(transform.position, waypoints[index].position) > 0.5f)
            {
                agent.SetDestination(waypoints[index].position);
            }
            else
            {
                if (index < (waypoints.Length - 1))
                {
                    index++;
                }
                else if (index == waypoints.Length - 1)
                {
                    index = 0;
                }
            }
        }            
    }
}
