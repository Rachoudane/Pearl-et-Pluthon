using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the PauseMenu UI
    private bool isPaused = false;

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Freeze the game
        isPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Reset time scale before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void ReturnHome()
    {
        Time.timeScale = 1f; // Réinitialise le temps avant de charger la scène
        SceneManager.LoadScene("Scene_0_Menu_Principal"); // Charge la scène du menu principal
        Debug.Log("Returning Home"); // Debug log for testing in the editor
    }
}
