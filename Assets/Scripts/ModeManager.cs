using UnityEngine;
using UnityEngine.UI; // For UI toggle
using UnityEngine.XR.Interaction.Toolkit;

public class ModeManager : MonoBehaviour
{
    public GameObject VRModePrefab; // Assign the VR mode prefab
    private XRInteractionManager sceneInteractionManager; // Dynamically find the XRInteractionManager
    private GameObject currentModeInstance;
    private bool isVRMode = false; // Tracks whether VR mode is currently active

    private void Start()
    {
        // Dynamically find the XRInteractionManager in the scene
        sceneInteractionManager = FindObjectOfType<XRInteractionManager>();
        if (sceneInteractionManager == null)
        {
            Debug.LogError("XRInteractionManager not found in the scene.");
        }
    }

    // This function is linked to the UI toggle button
    public void ToggleVRModeUI(Toggle toggle)
    {
        isVRMode = toggle.isOn; // Update the VR mode state based on the toggle's value
        Debug.Log($"VR Mode toggled: {(isVRMode ? "Enabled" : "Disabled")}");
    }

    // This function starts the game and initializes the appropriate mode
    public void StartGame()
    {
        // Destroy the current mode instance if it exists
        if (currentModeInstance != null)
        {
            Destroy(currentModeInstance);
        }

        if (isVRMode)
        {
            // Instantiate VR mode prefab
            currentModeInstance = Instantiate(VRModePrefab, Vector3.zero, Quaternion.identity);

            // Link the prefab interactors to the scene-wide XRInteractionManager
            XRBaseInteractor[] interactors = currentModeInstance.GetComponentsInChildren<XRBaseInteractor>(true); // Include inactive objects
            foreach (var interactor in interactors)
            {
                interactor.interactionManager = sceneInteractionManager;
            }

            Debug.Log("VR Mode initialized with scene-wide XRInteractionManager.");
        }
        else
        {
            Debug.Log("Non-VR Mode selected.");
        }
    }
}
