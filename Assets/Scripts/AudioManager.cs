﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager Instance;

    void Awake()
    {
        Instance = this;

        foreach(Sound s in sounds)
		{
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
		}
    }

	public void Play(string name)
	{
       Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
		{
            Debug.LogWarning("The sound" + " '" + name + "' " + "is not found!");
            return;
		}

        if(!s.source.isPlaying)
            s.source.Play();
	}

	public void Stop(string name)
	{
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("The sound" + " '" + name + "' " + "is not found!");
            return;
        }

        if(s.source.isPlaying)
            s.source.Stop();
    }

	void Update()
    {
        
    }
}
