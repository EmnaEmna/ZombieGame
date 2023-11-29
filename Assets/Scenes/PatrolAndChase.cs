using UnityEngine;
using UnityEngine.AI;

public class PatrolAndChase : MonoBehaviour
{
    public Transform[] waypoints; // Define waypoints for patrolling
    private int currentWaypoint = 0;
    private NavMeshAgent agent;
    private Transform player;
    public float detectionRange = 10f; // Set the detection range for the player
    public GameObject lose;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false; // To ensure smooth movement between waypoints

        // Find the player object by tag or another method
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (waypoints.Length > 0)
            agent.SetDestination(waypoints[0].position); // Start patrolling towards the first waypoint
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            ChasePlayer();
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (waypoints.Length == 0) return;

        agent.destination = waypoints[currentWaypoint].position;
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
    }

    bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            // Implement your method to check if the AI can "see" the player (e.g., raycasting, field of view checks)
            // Return true if the player is within the detection range and visible
            return true;
        }
        return false;
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
         if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
    {
        // The AI has arrived at the player's position
        Debug.Log("AI has reached the player's position.");
        // You can add additional actions here, like attacking the player or performing an action.
        lose.SetActive(true);
    }
    }
}
