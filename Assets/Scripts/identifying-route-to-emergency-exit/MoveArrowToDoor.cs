using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveArrowToDoor : MonoBehaviour
{
    public Transform Door2; // De positie van deur 2
    public Transform Door3; // De positie van deur 3
    private bool isNearDoor1 = false; // Controleert of de speler bij deur 1 is

    void Update()
    {
        Puzzle1();

        Puzzle2();
        
    }

    private void Puzzle1()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            // Verplaats de pijl naar de positie van deur 2
            transform.position = Door2.position + new Vector3(0, 1, 0);
        }
    }

    private void Puzzle2()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            
            // Verplaats de pijl naar de positie van deur 3
            transform.position = Door3.position + new Vector3(0, 1, 0);
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

