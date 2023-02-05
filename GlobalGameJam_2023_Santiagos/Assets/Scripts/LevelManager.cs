using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private int currentLevel = 1;
    
    [SerializeField] private RootController[] level1Roots = new RootController[3];
    [SerializeField] private RootController[] level2Roots = new RootController[4];
    [SerializeField] private float levelTime;
    [SerializeField] private bool[] HaveRootSpawned = new bool[5];
    private float timer;
    private bool levelEnded;

    [SerializeField] private GameObject loseScreen;
    
    [SerializeField] private GenerationZiguilini[] _generationZiguilinis = new GenerationZiguilini[6];

    private void Awake()
    {
        loseScreen.SetActive(false);
        if (Instance == null) Instance = this;
        else Destroy(this);
        for (int i = 0; i < HaveRootSpawned.Length; i++) HaveRootSpawned[i] = false;
    }

    void Start()
    {
        levelEnded = false;
        if (currentLevel == 1) StartCoroutine(Level1_RootManager());
        if (currentLevel == 2) StartCoroutine(Level2_RootManager());
        
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
    
    public IEnumerator Level2_RootManager()
    {
        levelTime = 120;
        timer = 0;
        foreach (var root in level1Roots) root.gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        level2Roots[0].gameObject.SetActive(true);
        HaveRootSpawned[0] = true;
        level2Roots[0].GetComponent<Animator>().SetTrigger("play");
        yield return new WaitForSeconds(10f);
        level2Roots[1].gameObject.SetActive(true);
        HaveRootSpawned[1] = true;
        level2Roots[1].GetComponent<Animator>().SetTrigger("play");
        yield return new WaitForSeconds(15f);
        level2Roots[2].gameObject.SetActive(true);
        HaveRootSpawned[2] = true;
        level2Roots[2].GetComponent<Animator>().SetTrigger("play");
        yield return new WaitForSeconds(20f);
        level2Roots[3].gameObject.SetActive(true);
        HaveRootSpawned[3] = true;
        level2Roots[3].GetComponent<Animator>().SetTrigger("play");
        
        StartCoroutine(GenerateEnemies2());
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
    
    public IEnumerator GenerateEnemies2()
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
            if (HaveRootSpawned[3])
            {
                if (_generationZiguilinis[3].EnemyInstances <= 3) EnemiesManager.Instance.HideAlert(3);
                Random random = new Random();
                float rnd = random.Next(5, 10);
                yield return new WaitForSeconds(rnd);
                //Spawn Enemies
                //Spawn Enemies
                _generationZiguilinis[3].CanSpawn = true;
                _generationZiguilinis[3].EnemyInstances = 8;
                EnemiesManager.Instance.ShowAlert(3);
            }
        }
    }

    private void EndLevel(int completedLevel)
    {
        Debug.Log("Completado el nivel " + completedLevel);
        levelEnded = true;
        if (completedLevel == 1)
        {
            SceneManager.LoadScene("Level 1 Outro");
        }
        else if (completedLevel == 2)
        {
            SceneManager.LoadScene("Level 3 Intro");
        }
        else if (completedLevel == 3)
        {
            SceneManager.LoadScene("Credits");
        }
    }

    public void Lose()
    {
        loseScreen.SetActive(true);
        foreach (var VARIABLE in level1Roots)
        {
            VARIABLE.gameObject.SetActive(false);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
