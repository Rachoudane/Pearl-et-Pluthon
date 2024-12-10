using System.Collections;
using UnityEngine;

public class TransitionZone : MonoBehaviour
{
    public SpriteRenderer iconPearl;      // Icon for Pearl character
    public SpriteRenderer iconPluthon;    // Icon for Pluthon character

    private bool pearlInZone = false;     // Flag to check if Pearl is inside the transition zone
    private bool pluthonInZone = false;   // Flag to check if Pluthon is inside the transition zone

    private bool transitionTriggered = false; // Flag to prevent triggering the transition multiple times

    public EndMenu endMenu; // Reference to the EndMenu script

    // Called when the script is first initialized
    private void Start()
    {
        // Initialize icons to be black (inactive state)
        iconPearl.color = Color.black;
        iconPluthon.color = Color.black;
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
            StartCoroutine(TriggerEndMenu(1f)); // Start a coroutine with a 1-second delay
        }
    }

    // Called when another collider exits the trigger zone
    private void OnTriggerExit2D(Collider2D other)
    {
        // If Pearl exits the zone, reset the flag and icon color
        if (iconPearl!=null&&other.CompareTag("Pearl"))
        {
            pearlInZone = false;
            iconPearl.color = Color.black; // Set icon back to black
        }
        // If Pluthon exits the zone, reset the flag and icon color
        else if (iconPluthon!=null&&other.CompareTag("Pluthon"))
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
