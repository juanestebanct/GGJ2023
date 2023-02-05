using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    private CameraManager _cameraManager;
    [SerializeField] private RootType _rootType = RootType.Left;
    [SerializeField] private GameObject cameraButton;

    private void Start()
    {
        _cameraManager = CameraManager.Instance;
        CameraManager.Instance.RootButtons.Add(cameraButton);
    }

    public void SetCamera()
    {
        if (_rootType == RootType.Left) _cameraManager.ChangeCamera(0);
        else if (_rootType == RootType.Right) _cameraManager.ChangeCamera(1);
        cameraButton.SetActive(false);
    }


}

public enum RootType
{
    Left = 0, Right = 1
}
