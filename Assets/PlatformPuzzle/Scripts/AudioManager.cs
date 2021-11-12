using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;

    public static AudioManager current;

    void Awake()
    {
        if (!HasMultipleInstances())
        {
            current = this;
            SetSounds();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Play("Theme");
    }

    void SetSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    bool HasMultipleInstances()
    {
        return current != null;
    }

    public void Play(string name)
    {
        try
        {
            Sound selectedSound = Array.Find(sounds, sound => sound.name == name);
            selectedSound.source.Play();
        }
        catch
        {
            Debug.LogWarning("Sound file '" + name + "' not found");
        }
    }
}
