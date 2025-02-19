using UnityEngine;
using TMPro; // For TextMeshPro UI

public class LapCounter : MonoBehaviour
{
    public TextMeshProUGUI lapCounterText; // UI element
    public int totalLaps = 3; // Set the total laps in the Inspector
    private int lapsCompleted = 0;

	public void IncrementLap()
	{
		lapsCompleted++;
		Debug.Log("Lap incremented: " + lapsCompleted); 

		if (lapsCompleted >= totalLaps)
		{
			Debug.Log("🏁 Race Finished!");
			lapCounterText.text = "Race Finished!";
			// Add logic to stop the race here if needed
		}
		else
		{
			UpdateLapCounter();
		}
	}

	private void UpdateLapCounter()
	{
		Debug.Log("Updating UI: Lap " + lapsCompleted + "/" + totalLaps); 
		lapCounterText.text = "Lap: " + lapsCompleted + " / " + totalLaps;
	}

    private void Start()
    {
        UpdateLapCounter(); // Initialize UI on start
    }
}
