using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public float timeLimit;

    [Header("Resolution")]
    public TMP_Dropdown resolutionDropdown; // Gebruik TMP_Dropdown voor TextMeshPro
    private Resolution[] resolutions;
    public Image brightnessOverlay; // Sleep je zwarte Image hierheen in de Inspector
    public Slider brightnessSlider; // Sleep je slider hierheen in de Inspector
    public Slider volumeSlider;
    public GameObject options;

    // Start is called before the first frame update

    public void StartGame()
    {
        GameManager.Instance.timeLimit = timeLimit;
        SceneManager.LoadScene("SchoolDemo");
        GameManager.Instance.volume = volumeSlider.value;
        GameManager.Instance.brightness = brightnessSlider.value;
        GameManager.Instance.canPause = true;
        GameManager.Instance.isRunning = true;

        // Stel de tijdslimiet in voor de CountDownTimer
        CountDownTimer.TimeLimit = timeLimit;
    }

    public void SetTimeLimit(float TimeLimit)
    {
        timeLimit = TimeLimit;
    }

    public void QuitGame()
    {
        Debug.Log("Application is quitting..."); // Dit is alleen zichtbaar in de editor.
        Application.Quit();
    }

    void Start()
    {
        //  Resolution();

        // Maak een lijst van drie specifieke resoluties
        string[] resolutionOptions = new string[] { "1920 x 1080", "1280 x 720", "800 x 600" };

        // Voeg de opties toe aan de dropdown
        resolutionDropdown.ClearOptions();
        foreach (string resolution in resolutionOptions)
        {
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolution));
        }

        // Voeg een listener toe die de resolutie wijzigt wanneer de gebruiker een keuze maakt
        resolutionDropdown.onValueChanged.AddListener(SetResolution);

        // Stel standaard de juiste resolutie in (optioneel)
        resolutionDropdown.value = 0; // Start met 1920 x 1080
        resolutionDropdown.RefreshShownValue();
        // Stel de sliderwaarde in (1 = volledig helder, 0 = volledig donker)
        brightnessSlider.value = 1;
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
    }

    public void SetBrightness(float value)
    {
        // Pas de Alpha aan van het zwarte overlay
        Color overlayColor = brightnessOverlay.color;
        overlayColor.a = 1 - value; // 1 = volledig helder, 0 = volledig donker
        brightnessOverlay.color = overlayColor;
    }

    public void SetResolution(int index)
    {
        // Pas de resolutie aan op basis van de geselecteerde index
        switch (index)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen = false);
                break;
            case 1:
                Screen.SetResolution(1280, 720, Screen.fullScreen = false);
                break;
            case 2:
                Screen.SetResolution(800, 600, Screen.fullScreen = false);
                break;
            default:
                break;
        }

        // Optioneel: debug-log om te controleren welke resolutie geselecteerd is
        Debug.Log($"Resolution set to: {resolutionDropdown.options[index].text}");
    }

    public void Opties()
    {
        GameManager.Instance.OpenMenu();
    }
}
