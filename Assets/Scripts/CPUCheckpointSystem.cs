using UnityEngine;

public class CPUCheckpointSystem : PlayerCheckpointSystem
{
    public LapCounter LapCounter; // Separate lap counter for CPU

    private int cpuCurrentWaypointIndex = 0;
    private int cpuWaypointsHit = 0;

    void Start()
    {
        ShowNextCPUWaypoint();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CPU Waypoint"))
        {
            Debug.Log("CPU Hit: " + other.transform.name + " | Expected: " + waypoints[cpuCurrentWaypointIndex].name);

            if (other.transform == waypoints[cpuCurrentWaypointIndex])
            {
                cpuWaypointsHit++;
                Debug.Log("CPU Waypoints hit: " + cpuWaypointsHit);

                other.GetComponent<Collider>().enabled = false;

                cpuCurrentWaypointIndex++;

                if (cpuCurrentWaypointIndex >= waypoints.Length)
                {
                    Debug.Log("CPU Lap Completed!");
                    cpuCurrentWaypointIndex = 0;

                    ResetCPUWaypoints();

                    if (LapCounter != null)
                    {
                        LapCounter.IncrementLap();
                    }
                    else
                    {
                        Debug.LogError("🚨 CPU LapCounter is NOT assigned!");
                    }
                }
                ShowNextCPUWaypoint();
            }
            else
            {
                Debug.Log("CPU Wrong waypoint! Go back.");
            }
        }
    }

    void ResetCPUWaypoints()
    {
        foreach (Transform waypoint in waypoints)
        {
            if (waypoint.CompareTag("CPU Waypoint"))
            {
                waypoint.GetComponent<Collider>().enabled = true;
            }
        }
    }

    void ShowNextCPUWaypoint()
    {
        foreach (Transform waypoint in waypoints)
        {
            if (waypoint.CompareTag("CPU Waypoint"))
            {
                Transform indicator = waypoint.Find("WaypointIndicator");
                if (indicator != null)
                {
                    indicator.gameObject.SetActive(false);
                }
            }
        }

        if (cpuCurrentWaypointIndex < waypoints.Length)
        {
            Transform nextIndicator = waypoints[cpuCurrentWaypointIndex].Find("WaypointIndicator");
            if (nextIndicator != null)
            {
                nextIndicator.gameObject.SetActive(true);
            }
        }
    }
}
