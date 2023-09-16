using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsLoader : MonoBehaviour
{
    public void LoadSettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }
}
