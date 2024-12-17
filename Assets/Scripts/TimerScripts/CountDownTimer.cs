using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    private float timeRemaining = 180f; // Default 3 minutes
    public bool StartBool;
    public GameObject TimerScreen; // UI Timer Screen
    public bool IsEasterEggActive = false; // Indicates if the easter egg is active

    private const float MIN_TIME = 60f; // 1 minute in seconds
    private const float MAX_TIME = 600f; // 10 minutes in seconds

    void Start()
    {
        StartBool = false;
        Timer.text = "03:00";
        Timer.color = Color.green;
    }

    void Update()
    {
        if (timeRemaining < 0)
        {
            SceneManager.LoadScene("faal");
        }
        if (StartBool && TimerScreen.activeSelf)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                int minutes = Mathf.FloorToInt(timeRemaining / 60);
                int seconds = Mathf.FloorToInt(timeRemaining % 60);
                Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                // Change color
                if (timeRemaining < 90f && timeRemaining > 30f)
                {
                    Timer.color = Color.yellow;
                }
                else if (timeRemaining <= 30f)
                {
                    Timer.color = Color.red;
                }
            }
            else
            {
                Timer.text = "00:00";
                Timer.color = Color.white;
            }
        }
    }

    public void StartGame()
    {
        StartBool = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void AddTime()
    {
        if (!IsEasterEggActive && timeRemaining + 60f <= MAX_TIME)
        {
            timeRemaining += 60f;
        }
        UpdateTimerDisplay();
    }

    public void DecreaseTime()
    {
        if (!IsEasterEggActive && timeRemaining - 60f >= MIN_TIME)
        {
            timeRemaining -= 60f;
        }
        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Update color based on time
        if (timeRemaining > 90f)
        {
            Timer.color = Color.green;
        }
        else if (timeRemaining > 30f)
        {
            Timer.color = Color.yellow;
        }
        else
        {
            Timer.color = Color.red;
        }
    }

    public void ActivateEasterEgg()
    {
        IsEasterEggActive = true;
        timeRemaining = 10f;
        UpdateTimerDisplay();
    }

    public void DeactivateEasterEgg()
    {
        IsEasterEggActive = false;
    }
}
