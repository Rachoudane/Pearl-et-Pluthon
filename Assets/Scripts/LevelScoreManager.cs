using UnityEngine;

public class LevelScoreManager : MonoBehaviour
{
    public int poissons = 0;       // Poissons collectés
    public bool plumeCollectee = false; // Plume dorée obtenue ou non

    private Chronometer chronometer; // Référence au script Chronometer

    private void Start()
    {
        // Trouve le script Chronometer automatiquement dans la scène
        chronometer = FindFirstObjectByType<Chronometer>();
    }

    public void AjouterPoisson()
    {
        poissons++;
    }

    public void CollecterPlume()
    {
        plumeCollectee = true;
    }

    public string GetFormattedTime()
    {
        // Récupère et formate le temps depuis le Chronometer
        if (chronometer != null)
        {
            float elapsedTime = chronometer.GetElapsedTime();
            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        return "00:00";
    }

    public void ResetScores()
    {
        poissons = 0;
        plumeCollectee = false;

        // Réinitialise le chronomètre
        if (chronometer != null)
        {
            chronometer.StartChronometer();
        }
    }
}
