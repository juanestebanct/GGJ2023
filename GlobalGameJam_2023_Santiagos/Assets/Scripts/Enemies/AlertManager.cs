using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertManager : MonoBehaviour
{
    public static AlertManager Instance;

    public List<GameObject> Alerts;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
        Alerts = new List<GameObject>();
    }
    private void Start()
    {
        foreach (var alert in Alerts) alert.SetActive(false);
    }
    public void ShowAlert(int root)
    {
        Alerts[root].SetActive(true);
    }
    public void HideAlert(int root)
    {
        Alerts[root].SetActive(false);
    }
}
