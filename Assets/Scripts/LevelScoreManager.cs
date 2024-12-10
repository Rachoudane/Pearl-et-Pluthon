using System;
using UnityEngine;

public class LevelScoreManager : MonoBehaviour
{
    // Tracks the number of fish collected
    public int fish = 0;

    // Tracks whether the golden feather has been collected
    public bool FeatherCollected = false;

    // Reference to the Chronometer script
    private Chronometer chronometer;

    // Called when the script starts
    private void Start()
    {
        // Automatically finds the Chronometer script in the scene
        chronometer = FindFirstObjectByType<Chronometer>();
    }

    // Increments the fish count by 1
    public void AddFish()
    {
        fish++;
    }

    // Marks the feather as collected
    public void CollectFeather()
    {
        FeatherCollected = true;
    }

    // Retrieves and formats the elapsed time from the Chronometer
    public string GetFormattedTime()
    {
        if (chronometer != null)
        {
            // Get the elapsed time in seconds
            float elapsedTime = chronometer.GetElapsedTime();

            // Convert the time into minutes and seconds
            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);

            // Return the time as a string in MM:SS format
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }


        Console.WriteLine("Sorry but we didn't find the Chronometer!");
        // Return "00:00" as a fallback if the Chronometer is not found
        return "00:00";
    }

    // Resets the game scores and states
    public void ResetScores()
    {
        fish = 0; // Reset fish count
        FeatherCollected = false; // Reset feather status

        // Restart the chronometer if it exists
        if (chronometer != null)
        {
            chronometer.StartChronometer();
        }
    }
}