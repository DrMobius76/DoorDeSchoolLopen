using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    public GameObject interactionText; // UI Text to show interaction prompt
    public TextMeshProUGUI textElement; // The text content
    public Invertaris invertaris; // Reference to inventory
    public int id; // Keycard ID to differentiate between keys
    private bool isPlayerNearby; // Tracks if the player is within range

    void Start()
    {
        // Hide interaction text initially
        interactionText.SetActive(false);
    }

    void Update()
    {
        // Check if player is nearby and presses "E"
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            GrapKeycard();
            interactionText.SetActive(false); // Hide text after picking up
            Destroy(gameObject); // Remove the keycard from the scene
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the range
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactionText.SetActive(true);
            textElement.text = "Press E to pickup";
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player exits the range
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionText.SetActive(false);
        }
    }

    public void GrapKeycard()
    {
        if (id == 1)
        {
            invertaris.SetRedKey(true); // Add red key to inventory
        }
        else if (id == 2)
        {
            invertaris.SetBlueKey(true); // Add blue key to inventory
        }
    }
}
