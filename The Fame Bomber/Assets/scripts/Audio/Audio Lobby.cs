using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public AudioClip Musique;
    [SerializeField] Slider VolumeSlider;

    // Start is called before the first frame update 
    void Start()
    {
        VolumeSlider.value = 0.5f;
        music.volume = VolumeSlider.value;
        music.clip = Musique;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = VolumeSlider.value;
    }
}


