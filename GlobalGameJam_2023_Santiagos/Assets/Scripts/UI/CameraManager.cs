using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    
    [SerializeField] private GameObject minimap;
    [SerializeField] private GameObject minimapCamera;
    [SerializeField] private GameObject openMinimapBtn;
    [SerializeField] private GameObject[] cameras = new GameObject[6];
    [SerializeField] private GameObject[] fiumbotControllers = new GameObject[6];

    public List<GameObject> RootButtons = new List<GameObject>();
    public bool IsOnMinimap;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
        minimap.SetActive(true); minimapCamera.SetActive(true); openMinimapBtn.SetActive(false);
        cameras[0].SetActive(false); cameras[1].SetActive(false);
        IsOnMinimap = true;
    }

    private void Update()
    {
        if (!IsOnMinimap && !LevelManager.Instance.HasLose)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                AudioManager.Instance.Zoom_Out();
                OpenMinimap();
            }
        }
    }

    public void ChangeCamera(int camera)
    {
        if (!LevelManager.Instance.HasLose)
        {
            IsOnMinimap = false;
            SelectorManager.Instance.EnableMinimapSelector();
            SelectorManager.Instance.DisableSelectors();
            foreach (var rootButton in RootButtons) rootButton.SetActive(false);
            foreach (var cam in cameras) cam.SetActive(false);
            foreach (var fiumbot in fiumbotControllers) fiumbot.SetActive(false);
            foreach (GameObject button in RootButtons) button.SetActive(false);
        
            cameras[camera].SetActive(true);
            fiumbotControllers[camera].SetActive(true);

            minimap.SetActive(false);
            minimapCamera.SetActive(false);
            openMinimapBtn.SetActive(true);
        }
    }

    public void OpenMinimap()
    {
        if (!LevelManager.Instance.HasLose)
        {
            SelectorManager.Instance.DisableMinimapSelector();
            SelectorManager.Instance.EnableSelectors();
            IsOnMinimap = true;
            foreach (var fiumbot in fiumbotControllers) fiumbot.SetActive(false);
            foreach (var rootButton in RootButtons) rootButton.SetActive(true);
            minimap.SetActive(true);
            minimapCamera.SetActive(true);
            openMinimapBtn.SetActive(false);
            foreach (GameObject button in RootButtons) button.SetActive(true);
        }
    }
}
