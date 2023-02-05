using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using Random = System.Random;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private int currentLevel = 1;
    
    [SerializeField] private RootController[] level1Roots = new RootController[2];
    [SerializeField] private float levelTime;
    [SerializeField] private bool[] HaveRootSpawned = new bool[5];
    private float timer;
    private bool levelEnded;
    
    [SerializeField] private GenerationZiguilini[] _generationZiguilinis = new GenerationZiguilini[6];

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
        for (int i = 0; i < HaveRootSpawned.Length; i++) HaveRootSpawned[i] = false;
    }

    void Start()
    {
        levelEnded = false;
        if (currentLevel == 1)
        {
            StartCoroutine(Level1_RootManager());
        }
    }

    void Update()
    {
        if (timer < levelTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            EndLevel(currentLevel);
        }
        
    }

    public IEnumerator Level1_RootManager()
    {
        levelTime = 60;
        timer = 0;
        foreach (var root in level1Roots) root.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        level1Roots[0].gameObject.SetActive(true);
        HaveRootSpawned[0] = true;
        level1Roots[0].GetComponent<Animator>().SetTrigger("play");
        yield return new WaitForSeconds(10f);
        level1Roots[1].gameObject.SetActive(true);
        HaveRootSpawned[1] = true;
        level1Roots[1].GetComponent<Animator>().SetTrigger("play");
        yield return new WaitForSeconds(20f);
        level1Roots[2].gameObject.SetActive(true);
        HaveRootSpawned[2] = true;
        level1Roots[2].GetComponent<Animator>().SetTrigger("play");
        
        StartCoroutine(GenerateEnemies());
    }

    public IEnumerator GenerateEnemies()
    {
        while (!levelEnded)
        {
            if (HaveRootSpawned[0])
            {
                if (_generationZiguilinis[0].EnemyInstances <= 0) EnemiesManager.Instance.HideAlert(0);
                Random random = new Random();
                float rnd = random.Next(5, 15);
                yield return new WaitForSeconds(rnd);
                //Spawn Enemies
                _generationZiguilinis[0].CanSpawn = true;
                _generationZiguilinis[0].EnemyInstances = 5;
                EnemiesManager.Instance.ShowAlert(0);
            }
            if (HaveRootSpawned[1])
            {
                if (_generationZiguilinis[1].EnemyInstances <= 1) EnemiesManager.Instance.HideAlert(1);
                Random random = new Random();
                float rnd = random.Next(5, 15);
                yield return new WaitForSeconds(rnd);
                //Spawn Enemies
                _generationZiguilinis[1].CanSpawn = true;
                _generationZiguilinis[1].EnemyInstances = 5;
                EnemiesManager.Instance.ShowAlert(1);
            }
            if (HaveRootSpawned[2])
            {
                if (_generationZiguilinis[2].EnemyInstances <= 2) EnemiesManager.Instance.HideAlert(2);
                Random random = new Random();
                float rnd = random.Next(5, 15);
                yield return new WaitForSeconds(rnd);
                //Spawn Enemies
                //Spawn Enemies
                _generationZiguilinis[2].CanSpawn = true;
                _generationZiguilinis[2].EnemyInstances = 5;
                EnemiesManager.Instance.ShowAlert(2);
            }
        }
    }

    private void EndLevel(int completedLevel)
    {
        Debug.Log("Completado el nivel " + completedLevel);
        levelEnded = true;
    }
}
