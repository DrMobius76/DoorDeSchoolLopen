using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrowToDoor : MonoBehaviour
{
    public Transform Door1; // De positie van deur 1
    public Transform Door2; // De positie van deur 2
    public Transform Door3; // De positie van deur 3

    private Transform currentDoor; // Houdt bij boven welke deur de pijl zich bevindt
   
    void Start()
    {
        // Stel de standaard rotatie van de pijl in (rechtop met punt naar beneden)
        

        // Startpositie van de pijl boven deur 1
        currentDoor = Door1;
        UpdateArrowPosition();
    }

    void Update()
    {
        // Interacties om de pijl te verplaatsen
        if (Input.GetKeyDown(KeyCode.E))
        {
            MoveArrowTo(Door2);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            MoveArrowTo(Door3);
        }
    }

    private void MoveArrowTo(Transform targetDoor)
    {
        // Controleer of de pijl al bij de doeldeur is
        if (currentDoor == targetDoor)
        {
            Debug.Log("De pijl is al boven deze deur!");
            return;
        }

        // Verplaats de pijl naar de nieuwe deur
        currentDoor = targetDoor;
        UpdateArrowPosition();
    }

    private void UpdateArrowPosition()
    {
        // Positioneer de pijl boven de huidige deur
        if (currentDoor != null)
        {
            transform.position = currentDoor.position + new Vector3(0, 1, 0); // Verplaats de pijl boven de deur
        }
    }
}