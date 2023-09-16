using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameRunning = false;
    public TMP_Text startPauseButtonText;  // Drag your button's Text component here in the inspector

    void Start()
    {
        Time.timeScale = 0;
        UpdateStartPauseButtonText();
    }

    public void ToggleStartPause()
    {
        isGameRunning = !isGameRunning;
        UpdateStartPauseButtonText();

        if (isGameRunning)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
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
    }
}
