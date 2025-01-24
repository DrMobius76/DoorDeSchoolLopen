using UnityEngine;

public class MouseCameraRotation : MonoBehaviour
{
    public Transform player; // De speler of het middelpunt waar de camera rond draait
    public float distance = 5f; // Max afstand van de camera tot de speler
    public float sensitivity = 2f; // Gevoeligheid van de muis
    public float verticalRotationLimit = 80f; // Limiet voor verticale rotatie
    public LayerMask collisionMask; // Masker om te bepalen wat de camera blokkeert

    private float currentXRotation = 0f; // Houd de verticale rotatie bij
    private float currentYRotation = 0f; // Houd de horizontale rotatie bij

    void Start()
    {

    }

    void LateUpdate()
    {
        // Muisinput
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Horizontale rotatie
        currentYRotation += mouseX;

        // Verticale rotatie met limieten
        currentXRotation -= mouseY;
        currentXRotation = Mathf.Clamp(currentXRotation, -verticalRotationLimit, verticalRotationLimit);

        // Bereken de rotatie van de camera
        Quaternion rotation = Quaternion.Euler(currentXRotation, currentYRotation, 0);

        // Bepaal de maximale camera-offset
        Vector3 desiredCameraPosition = player.position - (rotation * Vector3.forward * distance);

        // Raycast om obstakels te detecteren
        RaycastHit hit;
        if (Physics.Raycast(player.position, desiredCameraPosition - player.position, out hit, distance, collisionMask))
        {
            // Als er een obstakel is, plaats de camera op de raakpositie
            transform.position = hit.point;
        }
        else
        {
            // Geen obstakel, gebruik de gewenste positie
            transform.position = desiredCameraPosition;
        }

        // Zorg ervoor dat de camera altijd naar de speler kijkt
        transform.LookAt(player);
    }
}