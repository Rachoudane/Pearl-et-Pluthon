using System.Collections;
using TMPro;
using UnityEngine;

public class TransitionZone : MonoBehaviour
{
    public GameObject scoreCanvas;        // Canvas d�affichage du score

    public SpriteRenderer iconPearl;     // Ic�ne pour Pearl
    public SpriteRenderer iconPluthon;   // Ic�ne pour Pluthon
    public SpriteRenderer iconFeather;

    private bool pearlInZone = false;
    private bool pluthonInZone = false;

    private LevelScoreManager scoreManager; // R�f�rence au gestionnaire de score

    private bool transitionTriggered = false; // Emp�che les r�p�titions

    private void Start()
    {
        // Initialisation
        iconPearl.color = Color.gray;
        iconPluthon.color = Color.gray;
        iconFeather.color = Color.gray;

        scoreCanvas.SetActive(false); // Cache le canvas de score au d�part

        scoreManager = FindFirstObjectByType<LevelScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pearl"))
        {
            pearlInZone = true;
            iconPearl.color = Color.white;
        }
        else if (other.CompareTag("Pluthon"))
        {
            pluthonInZone = true;
            iconPluthon.color = Color.white;
        }

        if (pearlInZone && pluthonInZone && !transitionTriggered)
        {
            transitionTriggered = true; // Emp�che la r�p�tition
            StartCoroutine(WaitAndShowScore(1f)); // D�lai d'une seconde
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pearl"))
        {
            pearlInZone = false;
            iconPearl.color = Color.gray;
        }
        else if (other.CompareTag("Pluthon"))
        {
            pluthonInZone = false;
            iconPluthon.color = Color.gray;
        }
    }

    private IEnumerator WaitAndShowScore(float delay)
    {
        yield return new WaitForSeconds(delay); // Attendre le d�lai

        AfficherScore();
    }

    private void AfficherScore()
    {
        Time.timeScale = 0; // Pause le jeu
        scoreCanvas.SetActive(true);

        // Met � jour les scores dans l�interface
        if (scoreManager != null)
        {
            scoreCanvas.transform.Find("PoissonsText").GetComponent<TMP_Text>().text =
                "Poissons collect�s : " + scoreManager.poissons;
            scoreCanvas.transform.Find("TempsText").GetComponent<TMP_Text>().text =
                "Temps r�alis� : " + scoreManager.GetFormattedTime();
            if (scoreManager.plumeCollectee)
            {
                iconFeather.color = Color.white;
            }
        }
    }

    public void ProchainNiveau()
    {
        Time.timeScale = 1; // Reprendre le jeu
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Recommencer()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void RetourMenuPrincipal()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_0_Menu_Principal");
    }
}
