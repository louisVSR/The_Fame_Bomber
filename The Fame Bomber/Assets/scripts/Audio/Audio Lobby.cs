using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public AudioClip Musique;
    [Range(0f, 1f)]
    public float volume;

    // Start is called before the first frame update 
    void Start()
    {
        music.volume = volume;
        music.clip = Musique;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = volume;
    }
}


