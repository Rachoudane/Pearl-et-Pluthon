using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the character moves horizontally
    public float jumpForce = 5f; // Force applied for jumping
    private Rigidbody2D rb; // Reference to the Rigidbody2D component (used for physics interactions)
    private bool isGrounded = true; // Flag to check if the player is grounded (on the floor)
    private SwitchCharacter switchCharacter; // Reference to the SwitchCharacter script to determine the active character

    public GameObject pearl; // Reference to the Pearl GameObject
    public GameObject pluthon; // Reference to the Pluthon GameObject

    // Called when the script is first initialized
    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();

        // Find the SwitchCharacter component in the scene to manage active character switching
        switchCharacter = FindFirstObjectByType<SwitchCharacter>(); // Finds the SwitchCharacter object automatically
        rb.freezeRotation = true; // Prevents rotation due to physics interactions

        // Ignore collisions between Pearl and Pluthon
        if (pearl != null && pluthon != null)
        {
            // Get the Collider2D components of both characters
            Collider2D pearlCollider = pearl.GetComponent<Collider2D>();
            Collider2D pluthonCollider = pluthon.GetComponent<Collider2D>();

            // If both characters have colliders, ignore collisions between them
            if (pearlCollider != null && pluthonCollider != null)
            {
                Physics2D.IgnoreCollision(pearlCollider, pluthonCollider); // Ignore collision between Pearl and Pluthon
            }
        }
    }

    // Called every frame
    void Update()
    {
        // Check if this player object is the active character
        if (switchCharacter.activeCharacter == this.gameObject)
        {
            // Horizontal movement input (e.g., arrow keys or A/D)
            float horizontalInput = Input.GetAxis("Horizontal"); // Returns a value between -1 and 1 based on input

            // Update the Rigidbody2D velocity for horizontal movement while keeping the current vertical velocity
            rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

            // Jump action
            if (Input.GetButtonDown("Jump") && isGrounded) // If the Jump button is pressed and the player is grounded
            {
                // Apply a vertical force to make the character jump
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Preserve the horizontal velocity while adding jump force
                isGrounded = false; // Set grounded flag to false when the player is in the air
            }
        }
    }

    // Called when the player collides with an object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with the ground (using tag to identify the ground)
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Set the isGrounded flag to true when the player touches the ground
            isGrounded = true;
        }
    }
}
