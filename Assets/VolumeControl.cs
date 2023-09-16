using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer;  // Drag your AudioMixer here in the Inspector
    public Scrollbar volumeScrollbar;  // Drag your Scrollbar UI component here

    private void Start()
    {
        volumeScrollbar.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        // Convert the scrollbar's value to decibels
        float dB = Mathf.Lerp(-80, 0, volume);
        audioMixer.SetFloat("MasterVolume", dB);
    }
}
