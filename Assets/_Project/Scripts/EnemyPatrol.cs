using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Settings")]
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waitTime = 1f;

    private NavMeshAgent agent;
    private int currentWaypointIndex;
    private float waitTimer;
    private bool waiting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        MoveToNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(waiting)
        {
            waitTimer += Time.deltaTime;

            if(waitTimer >= waitTime)
            {
                waiting = false;
                MoveToNextWaypoint();
            }

            return;
        }

        if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            waiting = true;
            waitTimer = 0f;
        }
    }

    private void MoveToNextWaypoint()
    {
        agent.SetDestination(waypoints[currentWaypointIndex].position);

        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }
}
