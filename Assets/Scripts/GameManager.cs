using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameRunning = false;
    public TMP_Text startPauseButtonText;  // Drag your button's Text component here in the inspector
    public Text crashText;
    public GameObject stageClearedText;
    public int currLevel;
    public bool pickedUpSpaceman = true;
    // True by default, spaceman levels should set this to false.
    void Start()
    {
        Time.timeScale = 0;
        UpdateStartPauseButtonText();
        crashText = GameObject.FindWithTag("crashUI").GetComponent<Text>();
        crashText.gameObject.SetActive(false); // Hide the text at the start of the level
        stageClearedText = GameObject.FindWithTag("winText");
        stageClearedText.SetActive(false); // Hide the text at the start of the level

    }

    public void PickUpSpaceman(){
        pickedUpSpaceman = true;
    }

    void Update(){
        if (isGameRunning)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void crash(){
        isGameRunning = false;
        startPauseButtonText.text = "Start";
        crashText.gameObject.SetActive(true);
    }

    public void clear(){
        if (!pickedUpSpaceman){
            return;
        }
        isGameRunning = false;
        stageClearedText.SetActive(true);
    }

    public void ToggleStartPause()
    {
        isGameRunning = !isGameRunning;
        UpdateStartPauseButtonText();
    }

    private void UpdateStartPauseButtonText()
    {
        startPauseButtonText.text = isGameRunning ? "Pause" : "Start";
    }

    public void ResetGame()
    {  
        isGameRunning = false;
        // Logic to reset the game (e.g., reset the positions of the spaceship and other objects)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reloads the current scene
        crashText.gameObject.SetActive(false);
    }

    public void GoToMainMenu(){
        isGameRunning = false;
        // Logic to reset the game (e.g., reset the positions of the spaceship and other objects)
        SceneManager.LoadScene("Main Menu");  // Reloads the current scene
        crashText.gameObject.SetActive(false);
        stageClearedText.SetActive(false);
    }

    public void NextLevel(){
        
        SceneManager.LoadScene("Level" + (currLevel+1).ToString());
    }
}
