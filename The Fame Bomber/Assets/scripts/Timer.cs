using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float chrono;
    public Text text_chrono;
    private void Start()
    {
        chrono = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        chrono += Time.deltaTime;
        text_chrono.text = Math.Round(chrono,1).ToString();
    }
}
