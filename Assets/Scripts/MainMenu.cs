using UnityEngine;
using UnityEngine.SceneManagement; // Needed to manage scene transitions

public class MainMenu : MonoBehaviour
{
    // Called when the "Play Game" button is clicked
    public void PlayGame()
    {
        // Load the main game scene, named "Scene_1_Apartment"
        SceneManager.LoadScene("Scene_1_Apartment");
    }

    // Called when the "Game Options" button is clicked
    public void GameOptions()
    {
        // Log a message to the console for debugging purposes
        Debug.Log("Game Options");
    }

    // Called when the "Quit Game" button is clicked
    public void QuitGame()
    {
        // Log a message to the console to indicate the game is quitting (useful in the Unity Editor)
        Debug.Log("Game Quit");

        // Quit the application (only works in a built version, not in the Unity Editor)
        Application.Quit();
    }
}