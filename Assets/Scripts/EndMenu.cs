using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public GameObject scoreCanvas;        // Canvas that displays the score
    public TMP_Text fishText;             // Text component for displaying fish count
    public TMP_Text chronoText;           // Text component for displaying elapsed time
    public SpriteRenderer iconFeather;    // Icon for the golden feather


    public LevelScoreManager scoreManager; // Reference to the score manager

    private void Start()
    {
        scoreCanvas.SetActive(false); // Hide the score canvas initially

        // Make sure the feather icon starts black
        if (iconFeather != null)
        {
            iconFeather.color = Color.black;
        }

        //Check if the LevelScoreManager is missing
        if (scoreManager == null)
        {
            Debug.LogError("LevelScoreManager is missing in the scene.");
        }
    }

    public void ShowEndMenu()
    {
        Time.timeScale = 0f; // Pause the game
        scoreCanvas.SetActive(true); // Show the score canvas

        if (scoreManager != null)
        {
            // Update the score display
            fishText.text = $"{scoreManager.fish}/10";
            chronoText.text = scoreManager.GetFormattedTime();

            // Show the feather icon if collected
            if (scoreManager.FeatherCollected && iconFeather != null)
            {
                iconFeather.color = Color.white;
            }
        }
        else
        {
            Debug.LogError("ScoreManager is missing in the scene.");
        }
    }

    // Method to transition to the next level (load next scene)
    public void NextLevel()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Method to restart the current level (reload current scene)
    public void Restart()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Method to return to the main menu (load main menu scene)
    public void ReturnHome()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene("Scene_0_Main_Menu"); // Load the main menu scene
    }
}
