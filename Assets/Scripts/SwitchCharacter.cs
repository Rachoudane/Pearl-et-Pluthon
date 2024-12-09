using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    public GameObject pearl;          // Reference to Pearl
    public GameObject pluthon;        // Reference to Pluthon
    public GameObject activeCharacter; // Currently active character
    public CameraFollow cameraFollow; // Reference to the CameraFollow script

    public CharacterUIManager uiManager; // Reference to the UI Manager for updating the UI

    void Start()
    {
        // Set Pearl as the default active character
        activeCharacter = pearl;
        cameraFollow.target = activeCharacter.transform; // Camera follows Pearl initially

        // Initialize UI to show Pearl
        if (uiManager != null)
        {
            uiManager.UpdateCharacterUI("Pearl", uiManager.pearlSprite); // Update UI for Pearl
        }
    }

    void Update()
    {
        // Switch character with the "Tab" key
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchActiveCharacter();
        }
    }

    void SwitchActiveCharacter()
    {
        // Toggle between Pearl and Pluthon
        if (activeCharacter == pearl)
        {
            activeCharacter = pluthon;
            if (uiManager != null)
            {
                uiManager.UpdateCharacterUI("Pluthon", uiManager.pluthonSprite); // Update UI for Pluthon
            }
        }
        else
        {
            activeCharacter = pearl;
            if (uiManager != null)
            {
                uiManager.UpdateCharacterUI("Pearl", uiManager.pearlSprite); // Update UI for Pearl
            }
        }

        // Update the camera to follow the active character
        cameraFollow.target = activeCharacter.transform;
    }
}
