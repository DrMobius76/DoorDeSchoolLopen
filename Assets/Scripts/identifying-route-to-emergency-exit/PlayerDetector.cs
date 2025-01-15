using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public GameObject numpadPrefab;
    private bool isPlayerInZone = false;
    public GameObject interactionText;
    public CodeManager codeManager; // Voeg een referentie naar CodeManager toe

    void FixedUpdate()
    { 
        if (isPlayerInZone && Input.GetKeyDown(KeyCode.K) && interactionText.activeSelf && !numpadPrefab.GetComponent<CodeManager>().codeCorrect)
        {
            Interact();
        }
    }

    public void Interact()
    {
        if (codeManager != null && codeManager.codeCorrect) // Controleer of de code correct is
        {
            return; // Doe niets als de code correct is
        }

        if (!numpadPrefab.activeSelf)
        {
            numpadPrefab.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            interactionText.SetActive(false);
        }
        else
        {
            numpadPrefab.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;
            interactionText.SetActive(true);
            Debug.Log("Player is in the Numpad-zone. Press K to activate the Numpad");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
            interactionText.SetActive(false);
            Debug.Log("Player Leaved the Numpad-zone");
        }
    }
}
