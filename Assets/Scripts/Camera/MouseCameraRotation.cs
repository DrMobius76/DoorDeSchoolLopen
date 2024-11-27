using UnityEngine;
public class MouseCameraMovement : MonoBehaviour
{
    public Transform player; // The Object turn around the camera
    public float distance = 5f; // Distance to the player
    public float minDistance = 1f;
    public float maxDistance = 5f;
    public float sensitivity = 5f; // Rotation sensitivity
    public float minY = -20f;
    public float maxY = 80f;
    public LayerMask collisionMask;

    public float currentX = 0f;
    public float currentY = 0f;
    private float adjustedDistance;


    void Start()
    {
        adjustedDistance = distance;
        
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * sensitivity;
            currentY -= Input.GetAxis("Mouse Y") * sensitivity;
            currentY =  Mathf.Clamp(currentY, minY, maxY);
        }
    }

    void LateUpdate()
    {
        
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        
        Vector3 desiredPosition = player.position - (rotation * Vector3.forward * distance);
        Vector3 direction = desiredPosition - player.position;
        RaycastHit hit;

        if (Physics.Raycast(player.position, direction.normalized, out hit, distance, collisionMask))
        {
          
            adjustedDistance = Mathf.Clamp(hit.distance, minDistance, distance);
        }
        else
        {
            
            adjustedDistance = distance;
        }

       
        Vector3 position = player.position - (rotation * Vector3.forward * adjustedDistance);
        transform.position = position;

   
        transform.LookAt(player);

       
        AdjustForVerticalObstacles();
    }

    void AdjustForVerticalObstacles()
    {
   
        RaycastHit verticalHit;
        if (Physics.Raycast(transform.position, Vector3.down, out verticalHit, 0.5f, collisionMask) ||
            Physics.Raycast(transform.position, Vector3.up, out verticalHit, 0.5f, collisionMask))
        {
            transform.position = verticalHit.point;
        }
    }
}