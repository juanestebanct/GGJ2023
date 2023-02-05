using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private int currentLevel = 1;
    
    [SerializeField] private RootController[] level1Roots = new RootController[2];

    [SerializeField] private int currenRond;
    [SerializeField] private int[] timeRonds;
    [SerializeField] private float timeRond;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    void Start()
    {
        //currenRond = 1; //inicia en ronda 1 
        //timeRond = timeRonds[0];
        if (currentLevel == 1)
        {
            StartCoroutine(Level1_RootManager());
        }
    }

    void Update()
    {
        switch (currenRond)
        {
            case 1:
                timeRond = -Time.deltaTime;
                if (timeRond<0) Debug.Log("acabo la ronda");
                break;
            case 2:
                break;
            case 3:
                break;

        }
    }

    public IEnumerator Level1_RootManager()
    {
        foreach (var root in level1Roots) root.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        level1Roots[0].gameObject.SetActive(true);
        level1Roots[0].GetComponent<Animator>().SetTrigger("play");
        yield return new WaitForSeconds(2f);
        level1Roots[1].gameObject.SetActive(true);
        level1Roots[1].GetComponent<Animator>().SetTrigger("play");
        yield return new WaitForSeconds(2f);
        level1Roots[2].gameObject.SetActive(true);
        level1Roots[2].GetComponent<Animator>().SetTrigger("play");
    }
}
