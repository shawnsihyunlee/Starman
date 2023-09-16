using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioSource audioSource;  // Drag your AudioSource component here
    public Scrollbar volumeScrollbar;  // Drag your Scrollbar UI component here

    private void Start()
    {
        volumeScrollbar.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
