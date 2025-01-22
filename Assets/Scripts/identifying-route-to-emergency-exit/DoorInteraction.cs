using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorInteraction : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;
    public int id; // ID van de deur (1 = rood, 2 = blauw)
    public Invertaris invertaris; // Referentie naar het inventory-systeem
    private bool isPlayerNearby; // Controleert of de speler dichtbij is
    public GameObject interaction;
    public TextMeshProUGUI textElement; // Tekst om de status van de deur weer te geven

    private void Update()
    {
        // Controleer continu of de speler in de buurt is en op "P" drukt
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            CheckAndOpenDoor();
        }
    }

    private void CheckAndOpenDoor()
    {
        if (id == 1 && invertaris.hasRedKey)
        {
            Door1.SetActive(false);
            Door2.SetActive(false);
            textElement.text = "Press E to open";
            Debug.Log("Deur 1 en 2 geopend!");
        }
        else if (id == 2 && invertaris.hasBlueKey)
        {
            OpenDoor(Door1, Door2);
            textElement.text = "Press E to open";
            Debug.Log("Deur 3 en 4 geopend!");
        }
        else
        {
            textElement.text = "No correct Keycard detected";
            Debug.Log("Error: Onjuiste keycard.");
        }
    }

    public void OpenDoor(GameObject door1, GameObject door2)
    {
        if (door1 != null) door1.SetActive(false);
        if (door2 != null) door2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Controleer of de speler de triggerzone binnenkomt
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            textElement.text = "Press E to open";
            Debug.Log("Player is near the door.");
            interaction.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Controleer of de speler de triggerzone verlaat
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Debug.Log("Player left the door area.");
            interaction.SetActive(false);

        }
    }
}
