using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f; // De snelheid van de speler
    public float gravity = -9.81f; // Gravitatiekracht
    public float jumpHeight = 2f; // De hoogte van de sprong
    public Transform cameraTransform;
    private CharacterController controller;
    private Vector3 velocity;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // Zorgt ervoor dat de animator wordt gekoppeld aan de dingen in Unity
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
                Jump();
                animator.SetBool("VictoryJump", true);
            }
            else
            {
                animator.SetBool("VictoryJump", false);
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

        Vector3 moveDirection = (forward * vertical + right * horizontal).normalized;

        controller.Move(moveDirection * speed * Time.deltaTime);

        //gigantische if statement is voor de animatie, detecteerd basicly of er een toets ingedrukt wordt en speelt dan de coresponderende animatie af
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsMoving", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Moonwalking", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("StravingRight", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("StravingLeft", true);
        }
        else if (Input.GetKey(KeyCode.T) && Input.GetKey(KeyCode.P))
        {
            animator.SetBool("TP", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("Moonwalking", false);
            animator.SetBool("StravingRight", false);
            animator.SetBool("StravingLeft", false);
            animator.SetBool("TP", false);
        }
    }

    void Jump()
    {
        // Bereken sprongsnelheid
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
