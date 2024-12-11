using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrowController : MonoBehaviour
{
    public Transform door2Position; // De positie van deur 2
    private bool isNearDoor1 = false; // Controleert of de speler bij deur 1 is

    void Update()
    {
        // Controleer of de speler op E drukt en dichtbij deur 1 is
        if (isNearDoor1 && Input.GetKeyDown(KeyCode.E))
        {
            // Verplaats de pijl naar de positie van deur 2
            transform.position = door2Position.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Controleer of de speler het triggergebied van deur 1 binnenkomt
        if (other.CompareTag("Player"))
        {
            isNearDoor1 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Controleer of de speler het triggergebied van deur 1 verlaat
        if (other.CompareTag("Player"))
        {
            isNearDoor1 = false;
        }
    }
}

