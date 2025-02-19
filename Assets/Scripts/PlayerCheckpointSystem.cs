using UnityEngine;
public class PlayerCheckpointSystem : MonoBehaviour
{
	public LapCounter lapCounter; // Reference to the LapCounter script
	public Transform[] waypoints;
	private int currentWaypointIndex = 0;
	private int waypointsHit = 0;
	void Start()
	{
		ShowNextWaypoint();
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Waypoint"))
		{
			Debug.Log("Hit: " + other.transform.name + " | Expected: " + waypoints[currentWaypointIndex].name);

			// Ensure we only count the waypoint once
			if (other.transform == waypoints[currentWaypointIndex])
			{
				waypointsHit++;
				Debug.Log("Waypoints hit: " + waypointsHit);

				// Disable the collider so it doesn't trigger multiple times
				other.GetComponent<Collider>().enabled = false;

				// Move to next waypoint
				currentWaypointIndex++;

				// If last waypoint is hit, restart for next lap
				if (currentWaypointIndex >= waypoints.Length)
				{
					Debug.Log("Lap Completed!");
					currentWaypointIndex = 0;

					// Reactivate all waypoint colliders for the next lap
				Debug.Log("Lap Completed!");
				currentWaypointIndex = 0;

				// Reactivate all waypoint colliders for the next lap
				ResetWaypoints();

				if (lapCounter != null)
				{
					Debug.Log("Calling IncrementLap()"); // ✅ Debug to confirm this runs
					lapCounter.IncrementLap();
				}
				else
				{
					Debug.LogError("🚨 LapCounter is NOT assigned!");
				}
				}
				ShowNextWaypoint();
			}
			else
			{
				Debug.Log("Wrong waypoint! Go back.");
			}
		}
	}
	
	void ResetWaypoints()
	{
		foreach (Transform waypoint in waypoints)
		{
			waypoint.GetComponent<Collider>().enabled = true;
		}
	}

	void ShowNextWaypoint()
	{
		foreach (Transform waypoint in waypoints)
		{
			// Find the indicator inside the waypoint and disable it
			Transform indicator = waypoint.Find("WaypointIndicator");
			if (indicator != null) 
			{
				indicator.gameObject.SetActive(false);
			}
		}

		// Show only the next waypoint's indicator
		if (currentWaypointIndex < waypoints.Length)
		{
			Transform nextIndicator = waypoints[currentWaypointIndex].Find("WaypointIndicator");
			if (nextIndicator != null)
			{
				nextIndicator.gameObject.SetActive(true);
			}
		}
	}



}


