using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    [SerializeField] private AudioSource player_as;
    [SerializeField] private AudioSource playerMovement_as;
    [SerializeField] private AudioSource roots_as;
    [SerializeField] private AudioClip[] sfx;

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
        Random random = new Random();
        
        roots_as.pitch = 1;
        roots_as.clip = sfx[random.Next(3,4)];
        roots_as.Play();
    }
    
    
    
}
