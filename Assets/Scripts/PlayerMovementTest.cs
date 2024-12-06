using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // De snelheid van de speler
    public float gravity = -9.81f; // Gravitatiekracht
    public float jumpHeight = 2f; // De hoogte van de sprong

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
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

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        // Bereken sprongsnelheid
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
