using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class DemoModeSwitcher : MonoBehaviour
{
    // This method switches to a specified scene by name
    public void SwitchScenes(string sceneName)
    {
        // Check if the scene exists in the build settings
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName); // Switch to the scene
        }
        else
        {
            Debug.LogError($"Scene '{sceneName}' cannot be loaded. Please ensure it is added to the build settings.");
        }
    }
}
