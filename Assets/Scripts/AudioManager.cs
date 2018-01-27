using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource efxSource;
	public float lowPitchRange = .95f;
	public float highPitchRange = 1.05f;

    public void PlaySingle(AudioData audio)
    {
        efxSource.clip = audio.clip;
        efxSource.Play();
    }

    public void RandomizeSfx(params AudioData[] audios)
    {
        int randomIndex = Random.Range(0, audios.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        efxSource.pitch = randomPitch;
        efxSource.clip = audios[randomIndex].clip;
        efxSource.Play();
    }
}
