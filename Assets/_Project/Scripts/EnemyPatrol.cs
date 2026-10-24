
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Settings")]
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waitTime = 1f;

    private NavMeshAgent agent;
    private EnemyDetection enemyDetection;

    private int currentWaypointIndex;
    private float waitTimer;
    private bool waiting;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyDetection = GetComponent<EnemyDetection>();

        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No patrol waypoints assigned.", this);
            return;
        }

        MoveToNextWaypoint();
    }

    private void Update()
    {
        if (waypoints.Length == 0 || agent == null)
            return;

        // Stop patrolling while the drone is detected.
        if (enemyDetection != null && enemyDetection.TargetDetected)
        {
            agent.isStopped = true;
            waiting = false;
            waitTimer = 0f;
            return;
        }

        // Resume movement when the drone is no longer detected.
        agent.isStopped = false;

        if (waiting)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= waitTime)
            {
                waiting = false;
                MoveToNextWaypoint();
            }

            return;
        }

        if (!agent.pathPending &&
            agent.remainingDistance <= agent.stoppingDistance)
        {
            waiting = true;
            waitTimer = 0f;
        }
    }

    private void MoveToNextWaypoint()
    {
        if (waypoints[currentWaypointIndex] == null)
            return;

        agent.SetDestination(waypoints[currentWaypointIndex].position);

        currentWaypointIndex =
            (currentWaypointIndex + 1) % waypoints.Length;
    }
}
