using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject minimap;
    [SerializeField] private GameObject minimapCamera;
    [SerializeField] private GameObject openMinimapBtn;
    [SerializeField] private GameObject[] cameras = new GameObject[2];

    private void Awake()
    {
        minimap.SetActive(true); minimapCamera.SetActive(true); openMinimapBtn.SetActive(false);
    }

    public void ChangeCamera(int camera)
    {
        if (camera == 1)
        {
            cameras[0].SetActive(false); cameras[1].SetActive(true); minimap.SetActive(false);
            minimapCamera.SetActive(false); openMinimapBtn.SetActive(true);
        }

        if (camera == 0)
        {
            cameras[1].SetActive(false); cameras[0].SetActive(true); minimap.SetActive(false);
            minimapCamera.SetActive(false); openMinimapBtn.SetActive(true);
        }
    }

    public void OpenMinimap()
    {
        minimap.SetActive(true);
        minimapCamera.SetActive(true);
        openMinimapBtn.SetActive(false);
    }
    
    
    
}
