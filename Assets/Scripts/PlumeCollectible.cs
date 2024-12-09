using UnityEngine;

public class PlumeCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pearl") || other.CompareTag("Pluthon"))
        {
            FindFirstObjectByType<LevelScoreManager>().CollecterPlume();
            Destroy(gameObject); // Supprime la plume
        }
    }
}