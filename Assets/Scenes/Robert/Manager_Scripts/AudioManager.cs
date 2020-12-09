using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] sounds;

    private void Start()
    {
        //gameObject.AddComponent<AudioSource>();
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume = 0.45f;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
            s.audioSource.playOnAwake = false;
        }       
        sounds[7].audioSource.volume = 0.2f;
        sounds[3].audioSource.pitch = 1;
        sounds[3].audioSource.loop = true;
        sounds[3].audioSource.volume = 0.35f;
        sounds[2].audioSource.volume = 1;
        sounds[13].audioSource.volume = 0.1f;
        sounds[13].audioSource.loop = true;
        PlayAudio("MenuMusic");
    }

    public void PlayAudio(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null)
        {
            Debug.Log("Incorrect audio string");
            return;
        }
        s.audioSource.Play();
    }

    public void StopAudio(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("Incorrect audio string");
            return;
        }
        s.audioSource.Stop();
    }
}
