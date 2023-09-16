using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLoader : MonoBehaviour
{
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
