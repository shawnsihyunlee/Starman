using UnityEngine;
using System;

public class Wormhole : MonoBehaviour
{
    [SerializeField]
    private GameObject entryPortal; // Reference to the entry portal GameObject.

    [SerializeField]
    private GameObject exitPortal; // Reference to the exit portal GameObject.

    private float entryPortalRotation; // Calculated entry portal rotation angle in degrees.
    private float exitPortalRotation; // Calculated exit portal rotation angle in degrees.

    private void Start()
    {
        // Calculate the entry portal rotation based on its position.
        if (entryPortal != null)
        {
            entryPortalRotation = entryPortal.transform.rotation.eulerAngles.z;
        }

        // Calculate the exit portal rotation based on its position.
        if (exitPortal != null)
        {
            exitPortalRotation = exitPortal.transform.rotation.eulerAngles.z;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            Teleport(other.gameObject);
        }
    }
    private void Teleport(GameObject objectToTeleport)
    {
        if (exitPortal != null)
        {
            // Access the entry and exit portal GameObjects.
            // You can use entryPortal and exitPortal references as needed.

            // Access the calculated rotations.
            Quaternion entryRotation = Quaternion.Euler(0f, 0f, entryPortalRotation);
            Quaternion exitRotation = Quaternion.Euler(0f, 0f, exitPortalRotation);

            

            Vector2 shipVelocity = objectToTeleport.GetComponent<Rigidbody2D>().velocity;
            float shipMagnitude = shipVelocity.magnitude;
            float entryAngle = Vector2.Angle(shipVelocity, entryPortal.transform.up);

            float exitAngle = exitPortalRotation - entryAngle;
            Vector2 exitDirection = Quaternion.Euler(0f,0f,exitAngle) * Vector2.up;



            // Set the new position and velocity of the object.
            objectToTeleport.transform.position = exitPortal.transform.position;
            objectToTeleport.GetComponent<Rigidbody2D>().velocity = exitDirection.normalized * shipMagnitude;
        }
    }

}
