using UnityEngine;

public class LevelScoreManager : MonoBehaviour
{
    public int poissons = 0;       // Poissons collect�s
    public bool plumeCollectee = false; // Plume dor�e obtenue ou non

    private Chronometer chronometer; // R�f�rence au script Chronometer

    private void Start()
    {
        // Trouve le script Chronometer automatiquement dans la sc�ne
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
        // R�cup�re et formate le temps depuis le Chronometer
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

        // R�initialise le chronom�tre
        if (chronometer != null)
        {
            chronometer.StartChronometer();
        }
    }
}
