using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f; // De snelheid van de speler
    public float gravity = -9.81f; // Gravitatiekracht
    public float jumpHeight = 2f; // De hoogte van de sprong
    public Transform cameraTransform;
    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // Reset verticale snelheid wanneer op de grond
            if (velocity.y < 0)
            {
                velocity.y = -2f; // Houd de speler stevig op de grond
            }

            // Controleer op sprong
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Dit werkt");
                Jump();
            }
        }

        // Pas zwaartekracht continu toe
        velocity.y += gravity * Time.deltaTime;

        // Beweeg speler
        Move();

        // Pas verticale beweging toe
        controller.Move(velocity * Time.deltaTime);
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 velocity = (forward * vertical + right * horizontal).normalized;

        controller.Move(velocity * speed * Time.deltaTime);
    }

    void Jump()
    {
        // Bereken sprongsnelheid
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}