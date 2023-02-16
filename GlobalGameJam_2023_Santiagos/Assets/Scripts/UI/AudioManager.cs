using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    [SerializeField] private AudioSource player_as;
    [SerializeField] private AudioSource ui_as;
    [SerializeField] private AudioSource roots_as;
    [SerializeField] private AudioClip[] sfx;
    [SerializeField] private AudioSource music_as;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    public void Player_Shoot()
    {
        player_as.pitch = 0.63f;
        player_as.clip = sfx[0];
        player_as.Play();
    }
    
    public void Spawn_Root()
    {
        roots_as.pitch = 1;
        roots_as.clip = sfx[5];
        roots_as.Play();
    }
    public void Zoom_In()
    {        
        ui_as.pitch = 1;
        ui_as.clip = sfx[2];
        ui_as.Play();
    }
    public void Zoom_Out()
    {
        ui_as.pitch = 1;
        ui_as.clip = sfx[3];
        ui_as.Play();
    }
    public void Boton_UI()
    {
        ui_as.pitch = 1;
        ui_as.clip = sfx[1];
        ui_as.Play();
    }
    public void Pause()
    {
        ui_as.pitch = 1;
        ui_as.clip = sfx[6];
        ui_as.Play();
        music_as.Pause();
    }
    public void Resume()
    {
        ui_as.pitch = 1;
        ui_as.clip = sfx[7];
        ui_as.Play();
        music_as.Play();
    }
    public void Dispario_Muerte()
    {
        roots_as.pitch = 1;
        player_as.clip = sfx[4];
        roots_as.Play();
    }





}
