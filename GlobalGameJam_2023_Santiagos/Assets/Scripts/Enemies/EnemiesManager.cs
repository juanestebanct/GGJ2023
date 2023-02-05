using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager Instance;

    public List<GameObject> Alerts = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
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
        Alerts[root].SetActive(true);
    }
}
