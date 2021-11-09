using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer masterMixer;
    public void AudioToggle (bool tickBox)
    {
        if (tickBox)
        {
            masterMixer.SetFloat("globalMasterVolume", 0f);
        }
        else
        {
            masterMixer.SetFloat("globalMasterVolume", -80f);
        }
    }
}
