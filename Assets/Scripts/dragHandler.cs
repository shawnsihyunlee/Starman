using UnityEngine;

public class DragHandler : MonoBehaviour
{
    private Vector3 difference = Vector3.zero;

    private void OnMouseDown(){
        difference = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private void OnMouseDrag(){
        transform.position = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }
}