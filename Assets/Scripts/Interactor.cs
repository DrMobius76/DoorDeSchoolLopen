using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public float interactionDistance = 3f; // Hoe ver je kunt interacteren
    public LayerMask interactableLayer; // Alleen op objecten in deze laag reageren
    public KeyCode interactKey = KeyCode.E; // Toets voor interactie

    public Camera playerCamera;

    void Start()
    {
    }

    void Update()
    {
        // Raycast vanaf het midden van de camera
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        // Debugging: teken de ray in de Scene View
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactionDistance, Color.green);

        // Voer de raycast uit
        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            // Debugging: Log welk object geraakt wordt
            Debug.Log("Raycast hit: " + hit.collider.name); // Toon naam van het object

            // Check of het object een interactable component heeft
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                Debug.Log("Press 'E' to interact"); // Vervang dit met UI logic

                // Controleer op interactie-toets
                if (Input.GetKeyDown(interactKey))
                {
                    interactable.Interact(); // Roep interactie aan
                }
            }
        }
    }
}
