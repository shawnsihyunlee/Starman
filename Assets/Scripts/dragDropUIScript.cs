using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DragDrop : MonoBehaviour
{
 
    public GameObject prefabToSpawn;
    public GameObject imageToClone; // Drag your UI image here in the inspector
    private GameObject clonedImage;
    private GameManager gameManager;
    public int numberOfPlanets = 0;
    private TextMeshProUGUI numText;
    
    void Start(){
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        numText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update(){
        numText.text = numberOfPlanets.ToString();
    }

    public void OnBeginDrag(BaseEventData eventData)
    {

        if(gameManager.isGameRunning){
            return;
        }
        
        if(numberOfPlanets <= 0){
            return;
        }

        PointerEventData pointerData = (PointerEventData) eventData;
        // Create a new instance of the object at the start of the drag
        clonedImage = Instantiate(imageToClone, imageToClone.transform.parent.parent);
        foreach (Transform child in clonedImage.transform)
        {
            Destroy(child.gameObject);
        }
        clonedImage.transform.position = pointerData.position;

        // Get the world bounds of the prefab
        Renderer rend = prefabToSpawn.GetComponent<Renderer>();
        if (rend == null) rend = prefabToSpawn.transform.GetChild(0).GetComponent<Renderer>();
        Bounds bounds = rend.bounds;
        
        // Convert the world bounds to screen space
        RectTransform canvasRect = clonedImage.transform.root.GetComponent<RectTransform>();
        Vector3 minScreen = Camera.main.WorldToScreenPoint(bounds.min);
        Vector3 maxScreen = Camera.main.WorldToScreenPoint(bounds.max);

        // Convert screen space coordinates to a size in canvas local space
        Vector2 minPosition;
        Vector2 maxPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, minScreen, null, out minPosition);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, maxScreen, null, out maxPosition);
        
        // Set the size of the cloned image
        RectTransform rectTransform = clonedImage.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(maxPosition.x - minPosition.x, maxPosition.y - minPosition.y);
    }
    

    public void OnDrag(BaseEventData eventData)
    {   
        if(gameManager.isGameRunning){
            return;
        }
        if(numberOfPlanets <= 0){
            return;
        }

        PointerEventData pointerData = (PointerEventData) eventData;
        // Update the position of the new object to follow the mouse cursor
        if (clonedImage != null)
        {
            clonedImage.transform.position = pointerData.position;
        }
    }

    public void OnEndDrag(BaseEventData eventData)
    {

        if(gameManager.isGameRunning){
            return;
        }
        if(numberOfPlanets <= 0){
            return;
        }

        // Logic to instantiate a planet in your game world when you stop dragging
        // You would use the position of the drop to determine where in the game world to create the planet
        // You might use a raycast or other method to find a point in the game world corresponding to the UI drop position
        PointerEventData pointerData = (PointerEventData) eventData;
        

        if (clonedImage != null)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clonedImage.transform.position);
            worldPosition.z = 0;  // Adjust z-coordinate to a suitable value
            Instantiate(prefabToSpawn, worldPosition, Quaternion.identity);

            Destroy(clonedImage);
            numberOfPlanets--;
        }
    }
}
