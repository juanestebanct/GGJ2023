using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    
    public int CurrentLevel = 1;
    [SerializeField] private float levelTime;
    [SerializeField] private float timer;
    private bool levelEnded;
    public bool HasLose;
    
    [SerializeField] private bool[] HaveRootSpawned = new bool[5];
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GenerationZiguilini[] _generationZiguilinis = new GenerationZiguilini[6];
    [SerializeField] private RootController[] level1Roots = new RootController[3];
    [SerializeField] private RootController[] level2Roots = new RootController[4];
    [SerializeField] private RootController[] level3Roots = new RootController[4];

    private void Awake()
    {
        HasLose = false;
        loseScreen.SetActive(false);
        if (Instance == null) Instance = this;
        else Destroy(this);
        for (int i = 0; i < HaveRootSpawned.Length; i++) HaveRootSpawned[i] = false;
    }

    void Start()
    {
        Time.timeScale = 1;
        levelEnded = false;
        if (CurrentLevel == 1) StartCoroutine(Level1_RootManager());
        if (CurrentLevel == 2) StartCoroutine(Level2_RootManager());
        if (CurrentLevel == 3) StartCoroutine(Level3_RootManager());
    }

    void Update()
    {
        if (!HasLose)
        {
            if (timer < levelTime) timer += Time.deltaTime;
            else EndLevel(CurrentLevel);
            GenerateEnemies();
        }
    }

    private IEnumerator Level1_RootManager()
    {
        if (levelTime <= 0) levelTime = 90;
        timer = 0;
        foreach (var root in level1Roots) root.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        SpawnRoot(1,0);
        yield return new WaitForSeconds(10f);
        SpawnRoot(1,1);
        yield return new WaitForSeconds(20f);
        SpawnRoot(1,2);
        
    }
    
    private IEnumerator Level2_RootManager()
    {
        if (levelTime <= 0) levelTime = 120;
        timer = 0;
        foreach (var root in level2Roots) root.gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        SpawnRoot(2,0);
        yield return new WaitForSeconds(10f);
        SpawnRoot(2,1);
        yield return new WaitForSeconds(10f);
        SpawnRoot(2,2);
        yield return new WaitForSeconds(10f);
        SpawnRoot(2,3);
    }
    
    private IEnumerator Level3_RootManager()
    {
        if (levelTime <= 0) levelTime = 200;
        timer = 0;
        foreach (var root in level3Roots) root.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        SpawnRoot(3,0);
        SpawnRoot(3,1);
        SpawnRoot(3,2);
        SpawnRoot(3,3);
        SpawnRoot(3,4);
    }

    private void SpawnRoot(int level, int root)
    {
        SelectorManager.Instance.EnableSelectorPosition(root);
        HaveRootSpawned[root] = true;
        AudioManager.Instance.Spawn_Root();
        switch (level)
        {
            case 1:
                Debug.Log("Entra Level 1");
                level1Roots[root].gameObject.SetActive(true);
                level1Roots[root].GetComponent<Animator>().SetTrigger("play");
                break;
            case 2:
                level2Roots[root].gameObject.SetActive(true);
                level2Roots[root].GetComponent<Animator>().SetTrigger("play");
                break;
            case 3:
                level3Roots[root].gameObject.SetActive(true);
                level3Roots[root].GetComponent<Animator>().SetTrigger("play");
                break;
        }
    } 

    private void GenerateEnemies()
    {
        if (HaveRootSpawned[0]) StartCoroutine(EnemySpawnDelay(0));
        if (HaveRootSpawned[1]) StartCoroutine(EnemySpawnDelay(1));
        if (HaveRootSpawned[2]) StartCoroutine(EnemySpawnDelay(2));
        if (HaveRootSpawned[3]) StartCoroutine(EnemySpawnDelay(3));
        if (HaveRootSpawned[4]) StartCoroutine(EnemySpawnDelay(4));
    }

    private IEnumerator EnemySpawnDelay(int root)
    {
        HaveRootSpawned[root] = false;
        
        while (!levelEnded)
        {
            yield return new WaitForEndOfFrame();
            if (_generationZiguilinis[root].EnemyInstances <= 0) AlertManager.Instance.HideAlert(root);
            Random random = new Random();
            float rnd = random.Next(0, 10);
            yield return new WaitForSeconds(rnd);
            if (CurrentLevel == 1) _generationZiguilinis[root].EnemyInstances = 1;
            if (CurrentLevel == 2) _generationZiguilinis[root].EnemyInstances = 2;
            if (CurrentLevel == 3) _generationZiguilinis[root].EnemyInstances = 3;
            _generationZiguilinis[root].CanSpawn = true;

            AlertManager.Instance.ShowAlert(root);
        }
    }

    private void EndLevel(int completedLevel)
    {
        levelEnded = true;
        if (completedLevel == 1) SceneManager.LoadScene("Level 2 Outro");
        else if (completedLevel == 2) SceneManager.LoadScene("Level 3 Intro");
        else if (completedLevel == 3) SceneManager.LoadScene("Credits");
    }

    public void Lose()
    {
        if (!HasLose)
        {
            SelectorManager.Instance.DisableSelectors();
            SelectorManager.Instance.DisableMinimapSelector();
            loseScreen.SetActive(true);
            HasLose = true;
            if (CurrentLevel == 1) foreach (var root in level1Roots) root.gameObject.SetActive(false);
            if (CurrentLevel == 2) foreach (var root in level2Roots) root.gameObject.SetActive(false);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
