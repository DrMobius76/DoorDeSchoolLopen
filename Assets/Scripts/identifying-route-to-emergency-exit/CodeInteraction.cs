using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeInteraction : MonoBehaviour
{
    public string correctCode = "1234"; // De juiste pincode
    private string enteredCode = "";   // De ingevoerde code
    public bool isCodeCorrect = false; // Controleert of de code correct is

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Druk op Enter om de code te bevestigen
        {
            if (enteredCode == correctCode)
            {
                Debug.Log("Correcte code ingevoerd!");
                isCodeCorrect = true;
            }
            else
            {
                Debug.Log("Verkeerde code. Probeer opnieuw.");
                enteredCode = ""; // Reset de invoer
            }
        }
    }

    public void EnterDigit(string digit)
    {
        enteredCode += digit; // Voeg een cijfer toe aan de ingevoerde code
        Debug.Log("Huidige code: " + enteredCode);
    }
}
