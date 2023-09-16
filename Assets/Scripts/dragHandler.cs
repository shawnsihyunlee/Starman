using UnityEngine;

public class DragHandler : MonoBehaviour
{
    private Vector3 difference = Vector3.zero;
    private GameManager gameManager;

    void Start(){
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown(){
        if (!gameManager.isGameRunning){
            difference = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
    }

    private void OnMouseDrag(){
        if (!gameManager.isGameRunning){
            transform.position = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
        }
    }

}