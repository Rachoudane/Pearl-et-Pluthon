using UnityEngine;
using UnityEngine.UIElements;

public class PushableObject : MonoBehaviour
{
    public float pushForce = 10f; // Force applied when pushing
    private Rigidbody2D rb;      // Rigidbody2D component of the pushable object

    // Tracks if Pluthon is touching and if the player is on top
    private bool isPluthonTouching = false;
    private bool isPearlTouching = false;
    private bool playerOnTop = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Only allow Pluthon to push the object if not standing on top
        if (IsPluthonPushing() && !playerOnTop)
        {
            rb.bodyType = RigidbodyType2D.Dynamic; // Allow movement
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0f)
            {
                // Apply horizontal force to push the object
                rb.AddForce(new Vector2(horizontalInput * pushForce, 0), ForceMode2D.Force);
            }
        }
        else if (IsPearlPushing())
        {
            // Freeze the object completely if not Pluthon or player is on top
            rb.bodyType = RigidbodyType2D.Kinematic; // Prevent physics interactions
            rb.linearVelocity = Vector2.zero; // Just in case residual velocity exists
            rb.angularVelocity = 0f;
        }
    }

    // Check if Pluthon is pushing
    private bool IsPluthonPushing()
    {
        // Check if Pluthon is the active character
        SwitchCharacter switchCharacter = FindFirstObjectByType<SwitchCharacter>();
        bool isActive = switchCharacter != null && switchCharacter.activeCharacter.CompareTag("Pluthon");

        // Return true only if Pluthon is active and touching the object
        return isActive && isPluthonTouching;
    }

    // Check if Pearl is pushing
    private bool IsPearlPushing()
    {
        // Check if Pearl is the active character
        SwitchCharacter switchCharacter = FindFirstObjectByType<SwitchCharacter>();
        bool isActive = switchCharacter != null && switchCharacter.activeCharacter.CompareTag("Pearl");

        // Return true only if Pluthon is active and touching the object
        return isActive && isPearlTouching;
    }

    // Detect collisions with Pluthon & Pearl to know if it's touching the object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pluthon"))
        {
            isPluthonTouching = true;

            // Check if the player is standing on top
            if (collision.contacts[0].normal.y < -0.5f) // Downward normal means "on top"
            {
                playerOnTop = true;
            }
        }
        else if (collision.gameObject.CompareTag("Pearl"))
        {
            isPearlTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pluthon"))
        {
            isPluthonTouching = false;
            playerOnTop = false; // Reset the "on top" flag
        }
        else if (collision.gameObject.CompareTag("Pearl"))
        {
            isPearlTouching = false;
        }
    }
}
