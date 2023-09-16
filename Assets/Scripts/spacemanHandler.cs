using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spacemanHandler : MonoBehaviour
{

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")) // If the colliding object has the tag "Player"
        {
            gameManager.PickUpSpaceman();
            Destroy(this.gameObject);
        }

    }
}
