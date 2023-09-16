using UnityEngine;

public class Wormhole : MonoBehaviour
{
    public GameObject exitWormhole; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            Teleport(other.gameObject);
        }
    }

    private void Teleport(GameObject objectToTeleport)
    {
        if (exitWormhole != null)
        {
            objectToTeleport.transform.position = exitWormhole.transform.position;
        }
    }
}
