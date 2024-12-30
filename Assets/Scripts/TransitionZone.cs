using System.Collections;
using UnityEngine;

public class TransitionZone : MonoBehaviour
{
    public SpriteRenderer iconPearl;      // Icon for Pearl character
    public SpriteRenderer iconPluthon;    // Icon for Pluthon character
    public SpriteRenderer iconFeather;    // Icon for the Golden Feather (new icon for transition)

    private bool pearlInZone = false;     // Flag to check if Pearl is inside the transition zone
    private bool pluthonInZone = false;   // Flag to check if Pluthon is inside the transition zone
    private bool featherCollected = false; // Flag to check if the Golden Feather is collected

    private bool transitionTriggered = false; // Flag to prevent triggering the transition multiple times

    public EndMenu endMenu; // Reference to the EndMenu script
    private LevelScoreManager scoreManager; // Reference to the LevelScoreManager to check for the Golden Feather

    // Called when the script is first initialized
    private void Start()
    {
        // Initialize icons to be black (inactive state)
        iconPearl.color = Color.black;
        iconPluthon.color = Color.black;
        iconFeather.color = Color.black; // Make the Feather icon black initially

        scoreManager = FindFirstObjectByType<LevelScoreManager>(); // Find the score manager to check feather status
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

        // Check if the Golden Feather has been collected
        if (scoreManager != null)
        {
            featherCollected = scoreManager.FeatherCollected;
        }

        // If both characters and the feather are in the zone and transition hasn't been triggered
        if (pearlInZone && pluthonInZone && featherCollected && !transitionTriggered)
        {
            transitionTriggered = true; // Prevent multiple transitions
            StartCoroutine(TriggerEndMenu(1f)); // Start a coroutine with a 1-second delay
        }
    }

    // Called when another collider exits the trigger zone
    private void OnTriggerExit2D(Collider2D other)
    {
        // If Pearl exits the zone, reset the flag and icon color
        if (other.CompareTag("Pearl"))
        {
            pearlInZone = false;
            iconPearl.color = Color.black; // Set icon back to black
        }
        // If Pluthon exits the zone, reset the flag and icon color
        else if (other.CompareTag("Pluthon"))
        {
            pluthonInZone = false;
            iconPluthon.color = Color.black; // Set icon back to black
        }
    }

    // Coroutine to trigger the end menu
    private IEnumerator TriggerEndMenu(float delay)
    {
        yield return new WaitForSeconds(delay);
        endMenu.ShowEndMenu(); // Call the EndMenu script to display the end menu
    }
}
