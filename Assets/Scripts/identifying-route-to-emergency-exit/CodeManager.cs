using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CodeManager : MonoBehaviour
{
    public string correctCode = "1234"; // De juiste pincode
    private string enteredCode = "";   // De code die de speler invoert
    public TextMeshProUGUI codeDisplay;    // Tekstveld om de ingevoerde code weer te geven
    public GameObject door1;
    public GameObject door2;
    public PlayerDetector playerDetector;
    public bool codeCorrect = false; // Maak deze variabele publiek

    void Start()
    {
        enteredCode = "";
        codeDisplay.text = enteredCode;
    }

    // Methode om een cijfer toe te voegen aan de invoer
    public void EnterDigit(string digit)
    {
        if (enteredCode.Length < 4) // Beperk invoer tot 4 cijfers
        {
            enteredCode += digit;
            codeDisplay.text = enteredCode; // Update de weergegeven code
        }
    }

    // Methode om de invoer te resetten
    public void ResetCode()
    {
        enteredCode = "";
        codeDisplay.text = enteredCode; // Reset de weergave
    }

    // Methode om de code te bevestigen
    public void ConfirmCode()
    {
        if (enteredCode == correctCode)
        {
            Debug.Log("De pincode is juist!");
            door1.SetActive(false);
            door2.SetActive(false);
            codeCorrect = true;
            gameObject.SetActive(false);
            playerDetector.done = true;
        }
        else
        {
            Debug.Log("De pincode is onjuist!");
            ResetCode(); // Reset de code na een foutieve invoer
        }
    }

    public void Checkcanvas()
    {
        if (codeCorrect)
        {
            gameObject.SetActive(false);
        }
    }
}

