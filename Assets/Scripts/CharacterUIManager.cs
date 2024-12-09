using UnityEngine;
using TMPro;

public class CharacterUIManager : MonoBehaviour
{
    public TextMeshProUGUI characterNameText; // Reference to the Text element
    public UnityEngine.UI.Image characterIcon; // Reference to the Image element

    public Sprite pearlSprite; // Icon for Pearl
    public Sprite pluthonSprite; // Icon for Pluthon

    // Call this function when the player switches characters
    public void UpdateCharacterUI(string characterName, Sprite characterSprite = null)
    {
        if (characterNameText != null)
        {
            characterNameText.text = characterName;
        }

        if (characterIcon != null && characterSprite != null)
        {
            characterIcon.sprite = characterSprite;
        }
    }
}
