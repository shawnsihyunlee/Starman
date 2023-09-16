using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGame_QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
