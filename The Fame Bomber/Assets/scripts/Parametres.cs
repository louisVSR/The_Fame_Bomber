using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Parametres : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("Vol", vol);
    }
    public void SetPleinEcran (bool pleinEcran)
    {
        Screen.fullScreen = pleinEcran;
    }
}
