using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Scrollbar volumeScrollbar;

    private void Start()
    {
        // Initialize the scrollbar's value to the current volume
        volumeScrollbar.value = AudioListener.volume;

        // Add a listener to detect when the scrollbar value changes
        volumeScrollbar.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
