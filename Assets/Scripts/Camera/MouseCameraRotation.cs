using UnityEngine;

public class MouseCameraRotation : MonoBehaviour
{
    public Transform player; // Referentie naar de speler
    public float distance = 5f; // Afstand tussen camera en speler
    public float sensitivity = 2f; // Gevoeligheid van de muis
    public float verticalRotationLimit = 80f; // Beperking op verticale rotatie
    public LayerMask collisionMask; // Obstakels voor de camera
    public float playerRotationSpeed = 5f; // Hoe snel de speler zich aanpast aan de camera

    private float currentXRotation = 0f;
    private float currentYRotation = 0f;

    void LateUpdate()
    {
        // Lees muisinvoer
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Update rotatie
        currentYRotation += mouseX;
        currentXRotation -= mouseY;
        currentXRotation = Mathf.Clamp(currentXRotation, -verticalRotationLimit, verticalRotationLimit);

        // Bereken camera rotatie en positie
        Quaternion rotation = Quaternion.Euler(currentXRotation, currentYRotation, 0);
        Vector3 desiredCameraPosition = player.position - (rotation * Vector3.forward * distance);

        // Raycast om obstakels te detecteren
        RaycastHit hit;
        if (Physics.Raycast(player.position, desiredCameraPosition - player.position, out hit, distance, collisionMask))
        {
            transform.position = hit.point;
        }
        else
        {
            transform.position = desiredCameraPosition;
        }

        // Zorg ervoor dat de camera naar de speler kijkt
        transform.LookAt(player);

        // Update spelerrotatie om de camera te volgen
        Vector3 cameraForward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
        player.rotation = Quaternion.Lerp(player.rotation, targetRotation, Time.deltaTime * playerRotationSpeed);
    }
}
