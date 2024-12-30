using UnityEngine;

public class PushableObject : MonoBehaviour
{
    public float pushForce = 5f; // Force applied to pushable objects
    private Rigidbody2D rb;      // Reference to Rigidbody2D
    private SwitchCharacter switchCharacter; // Reference to SwitchCharacter

    private bool isPluthonNearby = false; // Flag to check if Pluthon is near the object

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D component
        switchCharacter = FindObjectOfType<SwitchCharacter>(); // Get the SwitchCharacter script
    }

    void Update()
    {
        // Apply movement ONLY IF Pluthon is nearby and is the active character
        if (isPluthonNearby && IsPluthonActive())
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0f)
            {
                // Move the chair using velocity
                rb.linearVelocity = new Vector2(horizontalInput * pushForce, rb.linearVelocity.y);
            }
            else
            {
                // Stop the chair when no input is detected
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }
        }
        else
        {
            // Lock the chair when conditions aren't met
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    // Check if Pluthon is the active character
    private bool IsPluthonActive()
    {
        if (switchCharacter != null)
        {
            return switchCharacter.activeCharacter.CompareTag("Pluthon");
        }
        return false;
    }

    // Detect if Pluthon is in contact with the chair
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pluthon"))
        {
            isPluthonNearby = true; // Set flag when Pluthon collides
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pluthon"))
        {
            isPluthonNearby = false; // Reset flag when Pluthon leaves
        }
    }
}
