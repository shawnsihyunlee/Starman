using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsControl : MonoBehaviour
{
    public Dropdown fpsDropdown;

    private void Start()
    {
        // Add listener to the dropdown
        fpsDropdown.onValueChanged.AddListener(ChangeFps);
    }

    public void ChangeFps(int index)
    {
        switch(index)
        {
            case 0: // 30 fps
                Application.targetFrameRate = 30;
                break;
            case 1: // 60 fps
                Application.targetFrameRate = 60;
                break;
            case 2: // 144 fps
                Application.targetFrameRate = 144;
                break;
            default:
                break;
        }
    }
}
