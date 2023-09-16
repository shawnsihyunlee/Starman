using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class goalScript : MonoBehaviour
{

    public Text stageClearedText;

    // Start is called before the first frame update
    void Start()
    {
        stageClearedText = GameObject.FindWithTag("winText").GetComponent<Text>();
        stageClearedText.gameObject.SetActive(false); // Hide the text at the start of the level
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) // If the colliding object has the tag "Player"
        {
            stageClearedText.gameObject.SetActive(true); // Show the 'Stage Cleared' text
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
