using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screncontroller : MonoBehaviour
{
    public Toggle toggle;
    private int isFullscreen = 1; // 0 = false, 1 = true

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Fullscreen")) isFullscreen = PlayerPrefs.GetInt("Fullscreen");
        else isFullscreen = 1;
    }

    void Start()
    {
        if (isFullscreen == 1) Screen.fullScreen = true;
        else Screen.fullScreen = false;
        
        if (Screen.fullScreen) toggle.isOn = true;
        else toggle.isOn = false;
    }
    
    public void ActivefullCren(bool screen)
    {
        Screen.fullScreen = screen;
        if (screen) isFullscreen = 1;
        else isFullscreen = 0;
    }
}
