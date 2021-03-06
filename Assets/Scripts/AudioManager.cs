﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource efxSource;
    public AudioSource musicSource;
    public AudioSource moteurSource;

    public AudioData[] moteurAudio;
    public AudioData musicAudio;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    void Awake()
    {
		musicSource.clip = musicAudio.clip;
		musicSource.priority = musicAudio.priority;
		moteurSource.clip = moteurAudio[0].clip;
		moteurSource.priority = moteurAudio[0].priority;
		moteurSource.loop = true;
		moteurSource.volume = 0.3f;
        musicSource.loop = true;
        musicSource.volume = 0.3f;
		moteurSource.Play();
		musicSource.Play();
	}

    public void GearUp(int gear) {
        moteurSource.Stop();
        moteurSource.clip = moteurAudio[gear].clip;
        moteurSource.Play();
    }

    public void PlaySingle(AudioData audio)
    {
        efxSource.clip = audio.clip;
        efxSource.priority = audio.priority;
        efxSource.Play();
    }

    public void RandomizeSfx(params AudioData[] audios)
    {
        int randomIndex = Random.Range(0, audios.Length);
        efxSource.clip = audios[randomIndex].clip;
        efxSource.priority = audios[randomIndex].priority;
        efxSource.Play();
    }

    public void StopAll()
    {
        efxSource.Stop();
		musicSource.Stop();
		moteurSource.Stop();
    }
}
