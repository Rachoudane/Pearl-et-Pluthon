using UnityEngine;
using TMPro;

public class CharacterUIManager : MonoBehaviour
{
    // Reference to the UI Text element for displaying the character's name
    public TextMeshProUGUI characterNameText;

    // Reference to the UI Image element for displaying the character's icon
    public UnityEngine.UI.Image characterIcon;

    // Sprite (image) for Pearl's icon
    public Sprite pearlSprite;

    // Sprite (image) for Pluthon's icon
    public Sprite pluthonSprite;

    // Function to update the character's UI when switching characters
    // - `characterName`: The name of the character to display
    // - `characterSprite`: (Optional) The sprite of the character to display; defaults to null
    public void UpdateCharacterUI(string characterName, Sprite characterSprite = null)
    {
        // Update the character's name if the Text element is assigned
        if (characterNameText != null)
        {
            characterNameText.text = characterName;
        }

        // Update the character's icon if both the Image element and sprite are assigned
        if (characterIcon != null && characterSprite != null)
        {
            characterIcon.sprite = characterSprite;
        }
    }
}

