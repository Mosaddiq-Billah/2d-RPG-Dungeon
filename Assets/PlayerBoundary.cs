using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 lastValidPosition;

    public static PlayerBoundary instance;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastValidPosition = rb.position;
    }

    void Update()
    {
        // Keep player movement logic here
        // For instance: rb.velocity or rb.position changes

        if (IsOnFloor())
        {
            // Update the last valid position
            lastValidPosition = rb.position;
        }

        // Check if the player has left the floor
        if (!IsOnFloor())
        {
            Debug.Log("Player is NOTT on the floor");
            //PreventExit();
            rb.position = lastValidPosition;
        }
    }
    public float raycastDistance = 1f; // Distance to raycast in each direction


    public bool IsOnFloor()
    {
        // Check for collisions in all directions
        bool isOnFloor = false;

        // Raycast down
        isOnFloor |= CheckRaycast(Vector2.down);

        // Raycast up
        isOnFloor |= CheckRaycast(Vector2.up);

        // Raycast left
        isOnFloor |= CheckRaycast(Vector2.left);

        // Raycast right
        isOnFloor |= CheckRaycast(Vector2.right);

        return isOnFloor;
    }


    public bool IsOnFloorOnStart()
    {
        // Check for collisions in all directions
        bool isOnFloor1 = false;

        // Raycast down
        isOnFloor1 |= CheckRaycast(Vector2.down);

        // Raycast up
        isOnFloor1 |= CheckRaycast(Vector2.up);

        // Raycast left
        isOnFloor1 |= CheckRaycast(Vector2.left);

        // Raycast right
        isOnFloor1 |= CheckRaycast(Vector2.right);

        return isOnFloor1;
    }

    bool CheckRaycast(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance);
        if (hit.collider != null && hit.collider.CompareTag("Floor"))
        {
            Debug.Log($"Player is on the floor in direction: {direction}");
            return true; // The player is on the floor in this direction
        }
        return false; // Not on the floor in this direction
    }

    /* public bool IsOnFloor()
     {
         // Raycast to check if the player is still on the floor layer
         RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
         if (hit.collider != null && hit.collider.CompareTag("Floor"))
         {
             Debug.Log("Player is on the floor");
             return true;
         }

         return false;
     }

     void PreventExit()
     {
         // Implement logic to stop player movement or redirect them
         // For instance, zero out the velocity or move the player back slightly
         rb.velocity = Vector2.zero;

         // Alternatively, you can reposition the player slightly to the previous position
         Vector2 lastPosition = transform.position; // Store the last valid position in the Update method
         transform.position = lastPosition;
     }*/
}
