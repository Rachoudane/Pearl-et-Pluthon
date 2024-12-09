using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Chronometer : MonoBehaviour
{
    
    public TMP_Text timeText;
    private float elapsedTime; // Temps �coul�
    private bool isRunning = true; // Pour contr�ler si le chrono est actif ou non

    void Start()
    {
        elapsedTime = 0f;
    }

    void Update()
    {
        if (isRunning)
        {
            // Augmenter le temps �coul�
            elapsedTime += Time.deltaTime;

            // Convertir le temps �coul� en minutes et secondes
            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);

            // Afficher le temps au format MM:SS
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // M�thodes pour g�rer le chrono (si tu veux l�arr�ter en fin de niveau par exemple)
    public void StopChronometer()
    {
        isRunning = false;
    }

    public void StartChronometer()
    {
        isRunning = true;
        elapsedTime = 0f; // R�initialise si on red�marre
    }

    public float GetElapsedTime()
    {
        return elapsedTime; // Pour afficher le temps en fin de niveau
    }
}
