using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuitGame : MonoBehaviour
{
    // This method will be called when the quit button is pressed
    public void Quit()
    {
        // Log a message to confirm the quit action
        Debug.Log("Quit button pressed. Exiting the game...");

        // Quit the game in a built application
        Application.Quit();

#if UNITY_EDITOR
        // Stop play mode in the Unity Editor
        EditorApplication.isPlaying = false;
#endif
    }
}
