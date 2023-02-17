using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private float duration;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Animator branchAnimator;
    [SerializeField] private bool nextLevelIsNight;
    private void Start()
    {
        Time.timeScale = 1;
        loadingScreen.SetActive(false);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(duration);
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        branchAnimator.SetTrigger("Grow");
        if (nextLevelIsNight)
        {
            
        }
        yield return new WaitForSeconds(1f);
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!loadOperation.isDone) yield return null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(LoadSceneAsync());
        }
    }
}
