using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    [Range(0f, 1f)]
    public float volume;

    // Start is called before the first frame update 
    void Start()
    {
        audioSource.volume = volume;
        PlayMusic("country-dreams-country-ballad-621");
    }
    public void PlayMusic(string name)
    {
        AudioClip clipToPlay = Resources.Load<AudioClip>("Audio/" + name);
        audioSource.clip = clipToPlay;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volume;
    }
}


