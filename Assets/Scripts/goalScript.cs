using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class goalScript : MonoBehaviour
{

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) // If the colliding object has the tag "Player"
        {
            gameManager.clear();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
