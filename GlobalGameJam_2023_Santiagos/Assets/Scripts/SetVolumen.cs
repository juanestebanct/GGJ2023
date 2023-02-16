using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolumen : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider Master;
    public Slider Music;
    public Slider SFX;
    private void Awake()
    {
        Master.onValueChanged.AddListener(SetLevel);
        Music.onValueChanged.AddListener(SetLevelMusic);
        SFX.onValueChanged.AddListener(SetLevelSFX);
    }

    public void SetLevel(float SliderValue)
    {
        //Debug.Log(SliderValue);
        mixer.SetFloat("GeneralVol", Mathf.Log10(SliderValue) * 20);
    }

    public void SetLevelMusic(float SliderValue)
    {
        // mixer.SetFloat("MusicVol", SliderValue);
        mixer.SetFloat("MusicVol", Mathf.Log10(SliderValue) * 20);
    }
    public void SetLevelSFX(float SliderValue)
    {
        //mixer.SetFloat("VFXVol", SliderValue);
        mixer.SetFloat("VFXVol", Mathf.Log10(SliderValue) * 20);
    }


}
