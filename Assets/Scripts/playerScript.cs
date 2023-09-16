using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public Vector2 initialVelocity;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = initialVelocity;
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
    }
}
