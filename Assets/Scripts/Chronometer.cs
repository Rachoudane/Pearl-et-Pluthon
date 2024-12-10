using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Chronometer : MonoBehaviour
{
    // Reference to the TextMeshPro UI element for displaying the time
    public TMP_Text timeText;

    // Variable to store the elapsed time in seconds
    private float elapsedTime;

    // Controls whether the chronometer is running
    private bool isRunning = true;

    // Called when the script starts
    void Start()
    {
        // Initialize the elapsed time to 0
        elapsedTime = 0f;
    }

    // Called once per frame
    void Update()
    {
        // Check if the chronometer is active
        if (isRunning)
        {
            // Increase the elapsed time by the time passed since the last frame
            elapsedTime += Time.deltaTime;

            // Convert the elapsed time into minutes and seconds
            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);

            // Display the elapsed time in MM:SS format
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // Stops the chronometer (e.g., at the end of a level)
    public void StopChronometer()
    {
        isRunning = false;
    }

    // Starts or restarts the chronometer
    public void StartChronometer()
    {
        isRunning = true;

        // Reset elapsed time to 0 if restarting
        elapsedTime = 0f;
    }

    // Retrieves the elapsed time for external use (e.g., level score display)
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
