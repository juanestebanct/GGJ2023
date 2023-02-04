using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras = new GameObject[2];

    public void ChangeCamera(int camera)
    {
        if (camera == 1)
        {
            cameras[0].SetActive(false); cameras[1].SetActive(true);
        }

        if (camera == 0)
        {
            cameras[1].SetActive(false); cameras[0].SetActive(true);
        }
    }
    
    
    
}
