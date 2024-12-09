using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Chronometer : MonoBehaviour
{
    
    public TMP_Text timeText;
    private float elapsedTime; // Temps écoulé
    private bool isRunning = true; // Pour contrôler si le chrono est actif ou non

    void Start()
    {
        elapsedTime = 0f;
    }

    void Update()
    {
        if (isRunning)
        {
            // Augmenter le temps écoulé
            elapsedTime += Time.deltaTime;

            // Convertir le temps écoulé en minutes et secondes
            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);

            // Afficher le temps au format MM:SS
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // Méthodes pour gérer le chrono (si tu veux l’arrêter en fin de niveau par exemple)
    public void StopChronometer()
    {
        isRunning = false;
    }

    public void StartChronometer()
    {
        isRunning = true;
        elapsedTime = 0f; // Réinitialise si on redémarre
    }

    public float GetElapsedTime()
    {
        return elapsedTime; // Pour afficher le temps en fin de niveau
    }
}
