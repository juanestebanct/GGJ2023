using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndKill : MonoBehaviour
{
    public GameObject Object;
    private bool isActive = false;
    private bool isPlayerInside;
   
    // Start is called before the first frame update
    void Start()
    {
        Object.SetActive(false);
        isActive = false;
        isPlayerInside = false;
    }

    private void Update()
    {
        if (isPlayerInside)
        {
            if (Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.K))
            {
                StartCoroutine(Activation());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            other.GetComponent<CharacterController>().CanShoot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            other.GetComponent<CharacterController>().CanShoot = false;
        }
        
    }

    IEnumerator Activation()
    {
        if (!isActive)
        {
            isActive = true;
            Object.SetActive(true);
            yield return new WaitForSeconds(0.8f);
            isActive = false;
            Object.SetActive(false);
        }
    }

}