using UnityEngine;

public class CameraSecundus : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    private float xRotation = 0f;

    void Start()
    {
        // Vergrendel de cursor in het midden van het scherm
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Haal de muisinvoer op
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Beperk de verticale rotatie
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Draai de camera op de X-as
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Draai de speler op de Y-as
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
