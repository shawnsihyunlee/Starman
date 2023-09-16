using UnityEngine;

public class OortCloud : MonoBehaviour
{
    public float dragForce = 1.0f; // Adjust this to control the strength of the drag force.

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the entered object has a Rigidbody2D component.
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        
        if (rb != null)
        {
            // Calculate and apply the drag force in the opposite direction of the object's velocity.
            Vector2 dragDirection = rb.velocity.normalized;
            Vector2 dragForceVector = dragDirection * dragForce;

            // Apply the drag force to the object.
            rb.AddForce(dragForceVector);

            // Debug message to check if the drag force is being applied.
            Debug.Log("Drag force applied to " + other.gameObject.name);
        }
    }
}