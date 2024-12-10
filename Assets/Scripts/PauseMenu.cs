using UnityEngine;
using UnityEngine.SceneManagement; // Needed to manage scene transitions

public class PauseMenu : MonoBehaviour
{
    // Reference to the Pause Menu UI GameObject
    public GameObject pauseMenuUI;

    // Tracks whether the game is currently paused or not
    private bool isPaused = false;

    // Called every frame to check if the Escape key is pressed
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the game is paused, resume it
            if (isPaused)
            {
                Resume();
            }
            // If the game is not paused, pause it
            else
            {
                Pause();
            }
        }
    }

    // Method to resume the game
    public void Resume()
    {
        // Hide the pause menu UI
        pauseMenuUI.SetActive(false);

        // Resume the game by setting the time scale to 1 (normal speed)
        Time.timeScale = 1f;

        // Set the isPaused flag to false to indicate the game is not paused
        isPaused = false;
    }

    // Method to pause the game
    public void Pause()
    {
        // Show the pause menu UI
        pauseMenuUI.SetActive(true);

        // Freeze the game by setting the time scale to 0 (no movement)
        Time.timeScale = 0f;

        // Set the isPaused flag to true to indicate the game is paused
        isPaused = true;
    }

    // Method to restart the current scene
    public void Restart()
    {
        // Reset time scale to 1 before restarting (ensures the game resumes properly)
        Time.timeScale = 1f;

        // Reload the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Method to return to the main menu scene
    public void ReturnHome()
    {
        // Reset time scale to 1 before switching scenes
        Time.timeScale = 1f;

        // Load the main menu scene
        SceneManager.LoadScene("Scene_0_Main_Menu");

        // Log a message for debugging (only visible in the Unity Editor)
        Debug.Log("Returning Home");
    }
}