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

    [SerializeField] private Animator nightToDay;
    [SerializeField] private Animator dayToNight;
    private void Start()
    {
        Time.timeScale = 1;

        if (SceneManager.GetActiveScene().name != "Credits")
        {
            loadingScreen.SetActive(false);
            nightToDay.enabled = false;
            dayToNight.enabled = false;
            if (nextLevelIsNight) nightToDay.gameObject.SetActive(false);
            else dayToNight.gameObject.SetActive(false);
        }
        
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(duration);
        if (SceneManager.GetActiveScene().name != "Credits") StartCoroutine(LoadSceneAsync());
        else SceneManager.LoadScene(sceneToLoad);
        
    }

    IEnumerator LoadSceneAsync()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        branchAnimator.SetTrigger("Grow");
        if (nextLevelIsNight) dayToNight.enabled = true;
        else nightToDay.enabled = true;
        yield return new WaitForSeconds(3.4f);
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
