using TMPro;
using UnityEngine;

public class ResultBar : MonoBehaviour
{
    public TMP_Text fishText;             // Text for displaying fish count
    public SpriteRenderer featherIcon;   // Icon for the golden feather

    private LevelScoreManager scoreManager;

    private void Start()
    {
        // Find the score manager in the scene
        scoreManager = FindFirstObjectByType<LevelScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("LevelScoreManager not found!");
        }
    }

    private void Update()
    {
        if (scoreManager != null)
        {
            // Update the fish count text
            fishText.text = $"{scoreManager.fish}/10";

            // Update the feather icon based on whether it's collected
            featherIcon.color = scoreManager.FeatherCollected ? Color.white : Color.black;
        }
    }
}
