using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public Vector2 initialVelocity;
    private GameManager gameManager;
    public GameObject arrowPrefab; // Drag your arrow prefab here in the inspector
    private GameObject arrowInstance; // To hold the instance of the arrow


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = initialVelocity;
        // Instantiate the arrow at the spaceship's position
        arrowInstance = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        if (arrowInstance != null)
        {
            // Set the arrow's rotation based on the initial velocity
            float angle = Mathf.Atan2(initialVelocity.y, initialVelocity.x) * Mathf.Rad2Deg;
            arrowInstance.transform.rotation = Quaternion.Euler(0, 0, angle);

            // Optionally, scale the arrow based on the magnitude of the initial velocity
            arrowInstance.transform.localScale = new Vector3(initialVelocity.magnitude*0.07f, initialVelocity.magnitude*0.03f, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        Vector2 velocity = rb.velocity;
        if (velocity != Vector2.zero) // Prevents rotation from resetting when velocity is zero
        {
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle+90);
        }

        if (arrowInstance != null)
        {   
            if (gameManager.isGameRunning)
                arrowInstance.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Obstacle")) // If the colliding object has the tag "Player"
        {
            gameManager.crash();
        }
    }
}
