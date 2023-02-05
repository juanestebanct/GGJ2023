using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOptions : MonoBehaviour
{

    [SerializeField] private AudioMixer _audioMixer;
    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
    public void CambiarVolumen(float volumen)
    {
        _audioMixer.SetFloat("Volumen", volumen);
    }
}
