using UnityEngine;

public class PushableObject : MonoBehaviour
{
    public float pushForce = 10f; // Force applied when pushing
    private Rigidbody2D rb;      // Rigidbody2D component of the pushable object

    // Tracks if the player is standing on top
    private bool playerOnTop = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Only allow Pluthon to push the object (check active character)
        if (IsPluthonPushing() && !playerOnTop) // Disable pushing if player is on top
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0f)
            {
                // Apply horizontal force to push the object
                rb.AddForce(new Vector2(horizontalInput * pushForce, 0), ForceMode2D.Force);
            }
        }
        else
        {
            // Stop the movement if conditions aren't met
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    // Check if the active character is Pluthon
    private bool IsPluthonPushing()
    {
        // Assuming the active character is managed by SwitchCharacter
        SwitchCharacter switchCharacter = FindFirstObjectByType<SwitchCharacter>();
        return switchCharacter != null && switchCharacter.activeCharacter.CompareTag("Pluthon");
    }

    // Detect if the player is on top of the object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pluthon"))
        {
            // Check if the player is above the object
            if (collision.contacts[0].normal.y < -0.5f) // Normal pointing downwards means on top
            {
                playerOnTop = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Reset flag when the player leaves
        if (collision.gameObject.CompareTag("Pluthon"))
        {
            playerOnTop = false;
        }
    }
}
