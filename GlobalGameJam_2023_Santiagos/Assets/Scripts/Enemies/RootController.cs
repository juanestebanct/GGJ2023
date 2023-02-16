using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    private CameraManager _cameraManager;
    [SerializeField] private int _rootScenario = 0;
    [SerializeField] private GameObject _cameraButton;
    [SerializeField] private GameObject _alert;

    private void Start()
    {
        _cameraManager = CameraManager.Instance;
        _cameraManager.RootButtons.Add(_cameraButton);
        AlertManager.Instance.Alerts.Add(_alert);
        _alert.SetActive(false);
        if (!_cameraManager.IsOnMinimap) _cameraButton.SetActive(false);
    }

    public void SetCamera()
    {
        if (_rootScenario == 0) _cameraManager.ChangeCamera(0);
        else if (_rootScenario == 1) _cameraManager.ChangeCamera(1);
        else if (_rootScenario == 2) _cameraManager.ChangeCamera(2);
        else if (_rootScenario == 3) _cameraManager.ChangeCamera(3);
        else if (_rootScenario == 4) _cameraManager.ChangeCamera(4);
        else if (_rootScenario == 5) _cameraManager.ChangeCamera(5);
        
        _cameraButton.SetActive(false);
    }
}
