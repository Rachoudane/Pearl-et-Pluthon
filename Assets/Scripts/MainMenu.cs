using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Charger la scène principale du jeu
        SceneManager.LoadScene("Scene_1_Appartement");
    }

    public void GameOptions()
    {
        Debug.Log("Game Options");
    }
    public void QuitGame()
    {
        Debug.Log("Game Quit"); // Pour tester dans l'éditeur
        Application.Quit(); // Quitte le jeu (ne fonctionne que dans une build)
    }
}
