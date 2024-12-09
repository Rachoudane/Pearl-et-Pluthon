using UnityEngine;

public class PoissonCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pearl") || other.CompareTag("Pluthon"))
        {
            FindFirstObjectByType<LevelScoreManager>().AjouterPoisson();
            Destroy(gameObject); // Supprime le poisson
        }
    }
}