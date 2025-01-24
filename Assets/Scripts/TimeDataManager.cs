using UnityEngine;

public class TimeDataManager : MonoBehaviour
{
    public static TimeDataManager Instance;

    public float TimerDuration = 180f; // Default to 3 minutes

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
