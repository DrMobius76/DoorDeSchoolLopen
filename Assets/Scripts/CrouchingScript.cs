using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchingScript : MonoBehaviour
{
    public CharacterController controller;
    public float crouchScaleY = 0.55f;  // Y scale when crouched
    public float standingScaleY = 1f;   // Y scale when standing
    public float crouchSpeed = 6f;      // Movement speed when crouched
    public float standingSpeed = 12f;  // Movement speed when standing

    private bool isCrouching = false;

    void Update()
    {
        HandleCrouching();
    }

    void HandleCrouching()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;

            if (isCrouching)
            {
                Crouch();
            }
            else
            {
                Stand();
            }
        }
    }

    void Crouch()
    {
        Vector3 scale = transform.localScale;
        scale.y = crouchScaleY; // Set the Y scale to the crouch value
        transform.localScale = scale;

        GetComponent<PlayerMovement>().Speed = crouchSpeed; // Reduce movement speed
    }

    void Stand()
    {
        Vector3 scale = transform.localScale;
        scale.y = standingScaleY; // Reset the Y scale to the standing value
        transform.localScale = scale;

        GetComponent<PlayerMovement>().Speed = standingSpeed; // Reset movement speed
    }
}
