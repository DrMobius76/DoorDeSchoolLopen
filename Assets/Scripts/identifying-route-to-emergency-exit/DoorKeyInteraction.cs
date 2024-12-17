using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyInteraction : MonoBehaviour
{
    public GameObject door1; 
    public GameObject door2; 
    public GameObject door3; 
    public GameObject door4;
    public GameObject door5;  
    public GameObject door6;  
    public GameObject door7;
    private bool isDoorUnlocked = false; // Controleert of de deur is geopend

    void Update()
    {
        Doorlockcheck1();

        Doorlockcheck2();

        Doorlockcheck3();
    }
    private void Doorlockcheck1()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Controleer of de deur al geopend is
        {
            door1.SetActive(false); // De deur wordt doorgankelijk
            door2.SetActive(false); // De deur wordt doorgankelijk
        }
    }
    private void Doorlockcheck2()
    {
        if (Input.GetKeyDown(KeyCode.I)) // Controleer of de deur al geopend is
        {
            door3.SetActive(false); // De deur wordt doorgankelijk
            door4.SetActive(false); // De deur wordt doorgankelijk
            
        }
    }

    private void Doorlockcheck3()
    {
        if (Input.GetKeyDown(KeyCode.U)) // Controleer of de deur al geopend is
        {
            door5.SetActive(false); // De deur wordt doorgankelijk
            door6.SetActive(false); // De deur wordt doorgankelijk
            door7.SetActive(false); // De deur wordt doorgankelijk
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Je bent bij de deur!");
            isDoorUnlocked = true; // Simuleer dat de sleutel is gevonden en de deur is geopend
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("De deur is vergrendeld");
            isDoorUnlocked = false; 
        }
    }
}
