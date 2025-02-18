using UnityEngine;

public class AICar : MonoBehaviour
{
    public Transform[] waypoints;  // Assign waypoints in the Inspector
    public float speed = 10f;
    public float turnSpeed = 5f;
    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Move towards the waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Rotate towards the waypoint
        Vector3 direction = targetWaypoint.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        // Switch to the next waypoint when close enough
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Loop waypoints
        }
    }
}
