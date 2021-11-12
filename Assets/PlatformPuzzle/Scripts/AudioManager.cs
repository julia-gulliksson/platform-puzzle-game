using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;

    public static AudioManager current;

    void Awake()
    {
        current = this;
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    private void Start()
    {

    }

    public void Play(string name)
    {
        Sound selectedSound = Array.Find(sounds, sound => sound.name == name);
        selectedSound.source.Play();
    }
}
