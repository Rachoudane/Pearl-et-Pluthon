using UnityEngine;

public class PoissonCollectible : MonoBehaviour
{
    // This method is called when another collider enters the trigger zone of this object
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger has the tag "Pearl" or "Pluthon"
        if (other.CompareTag("Pearl") || other.CompareTag("Pluthon"))
        {
            // Find the LevelScoreManager script and call its AddFish method
            FindFirstObjectByType<LevelScoreManager>().AddFish();

            // Destroy the fish object, effectively "collecting" it
            Destroy(gameObject);
        }
    }
}