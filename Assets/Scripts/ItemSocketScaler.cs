using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemSocketScaler : MonoBehaviour
{
    public Vector3 scaledSize = new Vector3(0.5f, 0.5f, 0.5f); // Desired size when in the socket
    public Vector3 originalSize; // To store the original size of the item

    private void OnTriggerEnter(Collider other)
    {
        // Check if the item is interactable
        XRGrabInteractable interactable = other.GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            originalSize = other.transform.localScale; // Store the original size
            other.transform.localScale = scaledSize;  // Resize the item
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Restore the item's original size when removed from the socket
        XRGrabInteractable interactable = other.GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            other.transform.localScale = originalSize;
        }
    }
}
