using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //Keeping same audioManager across scenes
        DontDestroyOnLoad(gameObject);

        foreach (Sound ost in sounds)
        {
            ost.source = gameObject.AddComponent<AudioSource>();
            ost.source.clip = ost.audioTrack;
            ost.source.volume = ost.volume;
            ost.source.pitch = ost.pitch;
            ost.source.loop = ost.loop;
            ost.source.outputAudioMixerGroup = ost.group;
        }
    }

    private void Start()
    {
        Play("Ambience");
    }

    public void Play(string audioToPlay)
    {
        Sound readyToPlay = Array.Find(sounds, sound => sound.name == audioToPlay);
        if (readyToPlay == null) return;
        readyToPlay.source.Play();
    }
}
