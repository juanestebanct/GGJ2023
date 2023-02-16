using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool pause;
    [SerializeField] private Opciones settingsMenu;
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
        pause = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Pause();
    }

    private void Pause()
    {
        if (!pause) { Time.timeScale = 0; pause = true; pauseMenu.SetActive(true); }
        else Resume();
    }

    public void Resume()
    {
        Time.timeScale = 1; pause = false; pauseMenu.SetActive(false); settingsMenu.Desactivar();
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
