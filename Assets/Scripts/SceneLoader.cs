using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevelScene()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadSettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LoadStoryScene()
    {
        SceneManager.LoadScene("Backstory");
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
