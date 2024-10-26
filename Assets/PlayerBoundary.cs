using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 lastValidPosition;

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

    bool IsOnFloor()
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
    }
}
