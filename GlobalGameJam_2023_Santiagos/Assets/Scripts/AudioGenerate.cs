using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGenerate : MonoBehaviour
{

    [SerializeField] private AudioSource[] Vfs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlaySound(int index)
    {
        Vfs[index].Play();
    }
}
