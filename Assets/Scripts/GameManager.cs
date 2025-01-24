using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float timeLimit;
    public float volume;
    public float brightness;
    public bool canPause = false;
    public GameObject optiesMenu;
    public bool yes;

    public bool isRunning;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Stel de instantie in
            DontDestroyOnLoad(gameObject); // Houd deze GameManager tussen scènes
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Vernietig duplicaten
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OpenMenu();
        }

        if(optiesMenu != null && !yes)
        {
            Menu  menu = FindAnyObjectByType<Menu>();
            menu.brightnessSlider.value = brightness;
            menu.volumeSlider.value = volume;
            yes = true;
        }
    }

    public void OpenMenu()
    {
        if (isRunning)
        {
            optiesMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            isRunning = false;
        }
        else
        {
            optiesMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            isRunning = true;
        }

    }
}
