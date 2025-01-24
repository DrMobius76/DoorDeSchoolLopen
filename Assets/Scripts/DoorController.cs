using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    public Transform hingePoint; // Het scharnierpunt (Hinge-object in de Hierarchy)
    public float openAngle = 90f; // Hoe ver de deur opent
    public float openSpeed = 2f; // Hoe snel de deur opent/sluit
    private bool isOpen = false; // Staat van de deur
    private Quaternion closedRotation; // Originele rotatie
    private Quaternion openRotation; // Rotatie bij openen
    private BoxCollider doorCollider; // Referentie naar de collider

    void Start()
    {
        // Bewaar de rotaties
        closedRotation = hingePoint.localRotation;
        openRotation = Quaternion.Euler(hingePoint.localRotation.eulerAngles + new Vector3(0, openAngle, 0));

        // Vind de Box Collider op de deur
        doorCollider = GetComponentInChildren<BoxCollider>();
    }

    void Update()
    {
        // Interpoleer tussen open en dicht
        Quaternion targetRotation = isOpen ? openRotation : closedRotation;
        hingePoint.localRotation = Quaternion.Slerp(hingePoint.localRotation, targetRotation, Time.deltaTime * openSpeed);
    }

    public void Interact()
    {
        Debug.Log("Ik werk");
        // Schakel de deur open/dicht en update collider
        isOpen = !isOpen;

        if (isOpen)
        {
            doorCollider.isTrigger = true; // Zet de collider op trigger wanneer open
        }
        else
        {
            doorCollider.isTrigger = false; // Zet de collider terug naar normaal wanneer gesloten
        }
    }
}
