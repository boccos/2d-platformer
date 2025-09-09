using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;  // Assign in Inspector

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            if (s.clip != null)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.loop = s.loop;
            }
        }
    }

    void Start()
    {
        Play("bg music"); // Play background music when game starts
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null || s.source == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null || s.source == null)
        {
            Debug.LogWarning("Sound: " + name + " not found or has no source!");
            return;
        }
        s.source.Stop();
    }

    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return s != null && s.source != null && s.source.isPlaying;
    }
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public float volume = 1f;
    public bool loop = false;

    [HideInInspector]
    public AudioSource source;
}
