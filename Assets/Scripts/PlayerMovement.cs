using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private SwitchCharacter switchCharacter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        switchCharacter = FindFirstObjectByType<SwitchCharacter>(); // Trouve le SwitchCharacter pour accéder à activeCharacter
    }

    void Update()
    {
        // Vérifie si ce personnage est le personnage actif
        if (switchCharacter.activeCharacter == this.gameObject)
        {
            // Mouvement horizontal
            float horizontalInput = Input.GetAxis("Horizontal");
            rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

            // Saut
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
