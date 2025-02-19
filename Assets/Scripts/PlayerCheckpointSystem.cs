using UnityEngine;

public class PlayerCheckpointSystem : MonoBehaviour
{
	public Transform[] waypoints;
	private int currentWaypointIndex = 0;
	private int waypointsHit = 0;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Waypoint"))
		{
			Debug.Log("Hit: " + other.transform.name + " | Expected: " + waypoints[currentWaypointIndex].name);

			if (other.transform == waypoints[currentWaypointIndex])
			{
				waypointsHit++;
				currentWaypointIndex++;
				Debug.Log("Waypoints hit: " + waypointsHit);

				// If last waypoint is hit, restart for next lap
				if (currentWaypointIndex >= waypoints.Length)
				{
					Debug.Log("Lap Completed!");
					currentWaypointIndex = 0;
				}
			}
			else
			{
				Debug.Log("Wrong waypoint! Go back.");
			}
		}
	}

}
