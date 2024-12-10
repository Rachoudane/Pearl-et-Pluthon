using System.Collections;
using TMPro;
using UnityEngine;

public class TransitionZone : MonoBehaviour
{
    public GameObject scoreCanvas;        // Canvas that displays the score
    public SpriteRenderer iconPearl;      // Icon for Pearl character
    public SpriteRenderer iconPluthon;    // Icon for Pluthon character
    public SpriteRenderer iconFeather;    // Icon for the golden feather

    private bool pearlInZone = false;     // Flag to check if Pearl is inside the transition zone
    private bool pluthonInZone = false;   // Flag to check if Pluthon is inside the transition zone

    private LevelScoreManager scoreManager; // Reference to the score manager to get the score

    private bool transitionTriggered = false; // Flag to prevent triggering the transition multiple times

    // Called when the script is first initialized
    private void Start()
    {
        // Initialize icons to be gray (inactive state)
        iconPearl.color = Color.gray;
        iconPluthon.color = Color.gray;
        iconFeather.color = Color.gray;

        scoreCanvas.SetActive(false); // Hide the score canvas initially

        // Find the LevelScoreManager in the scene to manage score data
        scoreManager = FindFirstObjectByType<LevelScoreManager>();
    }

    // Called when another collider enters the trigger zone (used for detection)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if Pearl entered the zone
        if (other.CompareTag("Pearl"))
        {
            pearlInZone = true; // Set flag for Pearl
            iconPearl.color = Color.white; // Show the Pearl icon
        }
        // Check if Pluthon entered the zone
        else if (other.CompareTag("Pluthon"))
        {
            pluthonInZone = true; // Set flag for Pluthon
            iconPluthon.color = Color.white; // Show the Pluthon icon
        }

        // If both characters are in the zone and transition hasn't been triggered
        if (pearlInZone && pluthonInZone && !transitionTriggered)
        {
            transitionTriggered = true; // Prevent multiple transitions
            StartCoroutine(WaitAndShowScore(1f)); // Start a coroutine with a 1-second delay
        }
    }

    // Called when another collider exits the trigger zone
    private void OnTriggerExit2D(Collider2D other)
    {
        // If Pearl exits the zone, reset the flag and icon color
        if (other.CompareTag("Pearl"))
        {
            pearlInZone = false;
            iconPearl.color = Color.gray; // Set icon back to gray
        }
        // If Pluthon exits the zone, reset the flag and icon color
        else if (other.CompareTag("Pluthon"))
        {
            pluthonInZone = false;
            iconPluthon.color = Color.gray; // Set icon back to gray
        }
    }

    // Coroutine that waits for a specified delay before showing the score
    private IEnumerator WaitAndShowScore(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        ShowScore(); // Call method to show the score
    }

    // Method to display the score and pause the game
    private void ShowScore()
    {
        Time.timeScale = 0f; // Pause the game

        scoreCanvas.SetActive(true); // Show the score canvas

        // Update the score display with the collected fish count and elapsed time
        if (scoreManager != null)
        {
            scoreCanvas.transform.Find("FishText").GetComponent<TMP_Text>().text =
                "Fish Collected : " + scoreManager.fish;
            scoreCanvas.transform.Find("TimeText").GetComponent<TMP_Text>().text =
                "Time : " + scoreManager.GetFormattedTime();

            // If the golden feather was collected, show the icon
            if (scoreManager.FeatherCollected)
            {
                iconFeather.color = Color.white;
            }
        }
    }

    // Method to transition to the next level (load next scene)
    public void NextLevel()
    {
        Time.timeScale = 1; // Resume the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Method to restart the current level (reload current scene)
    public void Restart()
    {
        Time.timeScale = 1f; // Resume the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // Method to return to the main menu (load main menu scene)
    public void ReturnHome()
    {
        Time.timeScale = 1f; // Resume the game
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_0_Main_Menu"); // Load the main menu scene
    }
}