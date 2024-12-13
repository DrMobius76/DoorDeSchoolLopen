using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyInteraction : MonoBehaviour
{
    public GameObject arrow; // De pijl die moet bewegen
    public Transform Door2; // De positie van deur 2
    public Transform Door3; // De positie van deur 3
    public BoxCollider doorCollider1; // De BoxCollider van de deur
    public BoxCollider doorCollider2; // De BoxCollider van de deur
    private bool isDoorUnlocked = false; // Controleert of de deur is geopend
    

    void Start()
    {
        doorCollider1.isTrigger = false; 
        doorCollider2.isTrigger = false; 
    }

    void Update()
    {
        Doorlockcheck1();

        Doorlockcheck2();
    }
    private void Doorlockcheck1()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Controleer of de deur al geopend is
        {
            doorCollider1.isTrigger = true; // De deur wordt doorgankelijk
            arrow.transform.position = Door2.position + new Vector3(0, 1, 0); // Verplaats de pijl naar de volgende deur
        }
    }
    private void Doorlockcheck2()
    {
        if (Input.GetKeyDown(KeyCode.I)) // Controleer of de deur al geopend is
        {
            doorCollider2.isTrigger = true; // De deur wordt doorgankelijk
            arrow.transform.position = Door3.position + new Vector3(0, 1, 0); // Verplaats de pijl naar de volgende deur
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
