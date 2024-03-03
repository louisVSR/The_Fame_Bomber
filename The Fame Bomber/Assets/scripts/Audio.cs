using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundData : MonoBehaviour
{
    public string soundName;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
}

public class AudioManager : MonoBehaviour
{
    public SoundData[] music,effect;
    public AudioSource musicSource, sfxsource;
    
    // Start is called before the first frame update 
    void Start()
    {
        PlayMusic("country-dreams-country-ballad-621");
        Debug.Log("Start");

    }
    public void PlayMusic(string name)
    {
        SoundData s = Array.Find(music, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
