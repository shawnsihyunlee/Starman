using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attract : MonoBehaviour
{

    GameObject spaceshipObject;
    Rigidbody2D spaceshipRigidbody;
    public float gravitationalConstant = -6.67430f;  // Adjust the value as necessary for your game
    public float mass; // Mass of the planet

    
    // Start is called before the first frame update
    void Start()
    {
        spaceshipObject = GameObject.FindWithTag("Player");
        spaceshipRigidbody = spaceshipObject.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        Rigidbody2D planetRigidbody = GetComponent<Rigidbody2D>();
        
        float m1 = spaceshipRigidbody.mass; // Mass of the spaceship
        
        Vector2 directionToSpaceship = spaceshipRigidbody.position - planetRigidbody.position;

        float distanceToSpaceship = directionToSpaceship.magnitude;
        if(distanceToSpaceship > 0)  // Avoid division by zero
        {
            float gravitationalForceMagnitude = gravitationalConstant * (m1 * mass) / Mathf.Pow(distanceToSpaceship, 2);
            Vector2 gravitationalForce = directionToSpaceship.normalized * gravitationalForceMagnitude;
            spaceshipRigidbody.AddForce(gravitationalForce);
        }
    }
}
