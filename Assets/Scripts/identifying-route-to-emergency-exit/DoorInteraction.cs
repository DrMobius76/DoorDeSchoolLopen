using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorInteraction : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;
    public GameObject Door3;
    public GameObject Door4;
    public int id; // ID van de deur (1 = rood, 2 = blauw)
    public Invertaris invertaris; // Referentie naar het inventory-systeem
    private bool isPlayerNearby; // Controleert of de speler dichtbij is
    public TextMeshProUGUI doorStatusText; // Tekst om de status van de deur weer te geven

    private void Update()
    {
        // Controleer continu of de speler in de buurt is en op "P" drukt
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.P))
        {
            CheckAndOpenDoor();
        }
    }

    private void CheckAndOpenDoor()
    {
        if (id == 1 && invertaris.hasRedKey)
        {
            OpenDoor(Door1, Door2);
            doorStatusText.text = "Deur 1 en 2 zijn open!";
            Debug.Log("Deur 1 en 2 geopend!");
        }
        else if (id == 2 && invertaris.hasBlueKey)
        {
            OpenDoor(Door3, Door4);
            doorStatusText.text = "Deur 3 en 4 zijn open!";
            Debug.Log("Deur 3 en 4 geopend!");
        }
        else
        {
            doorStatusText.text = "Je hebt niet de juiste keycard!";
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
            Debug.Log("Player is near the door.");
            doorStatusText.text = "Druk op 'P' om de deur te openen.";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Controleer of de speler de triggerzone verlaat
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Debug.Log("Player left the door area.");
            doorStatusText.text = ""; // Verwijder de tekst
        }
    }
}
