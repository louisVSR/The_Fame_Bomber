using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool JeuPause = false;
    public GameObject pauseMenu;
    void Start()
    {
        pauseMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JeuPause)
            {
                Resume();
            }
            else 
            { 
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        JeuPause = false;
    }

    void Pause ()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        JeuPause = true;
    }
    public void Chargement()
    { SceneManager.LoadScene(0);
      Time.timeScale = 1f;
    }
    public void Quit()
    {
        Debug.Log("q");
        Application.Quit();
    }
}
